using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Auth.Commands.Verify
{
    /// <summary>
    /// Подтверждение авторизации с помощью одноразового пароля.
    /// </summary>
    public class VerifyOTPCommandHandler : IRequestHandler<VerifyOTPCommand, AuthAccessModel>
    {
        private readonly IAuthRepository _authRepository;
        private JwtTokenService _jwtTokenService;

        public VerifyOTPCommandHandler(IRepositoryProvider provider, JwtTokenService jwtTokenService)
        {
            _authRepository = provider.GetRepository<IAuthRepository>();
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthAccessModel> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            // Существование записи с номером телефона.
            var auth = await _authRepository.Get(request.Phone, request.OTP);
            if (auth is null)
                throw new Exception("Сначала укажите номер телефона для получения код авторизации");
            
            auth.RetryCount += 1;

            // Соответствие кода.
            if (auth.OTP != request.OTP)
            {
                await _authRepository.Save(auth);
                throw new IncorrectOTPException();
            }

            // Не истёк ли срок действия кода.
            if (DateTime.Now > auth.OTPExpieredAt)
                throw new OTPExpieredException("Истек срок действия кода"); // Время жизни одноразового пароля истек.

            // Остались ли попытки для проверки.
            if (auth.RetryCount >= Global.AuthOTPRetryCount)
            {
                await _authRepository.Remove(auth.Id);
                // если попытки не остались, то просим пользователя заново ввести пароль для получения нового пароля
                throw new TooManyAttemptsOPTException("Истек количество ввода кода. Получите новый код");
            }

            // возвращаем токен
            auth.AccessToken = _jwtTokenService.GenerateToken(request.Phone);
            auth.AccessTokenExpieredAt = DateTime.Now.AddMinutes(15);

            auth.RefreshToken = _jwtTokenService.GenerateToken(request.Phone);
            auth.RefreshTokenExpieredAt = DateTime.Now.Date.AddDays(15);

            auth.OTP = String.Empty;
            await _authRepository.Save(auth);

            return auth;
        }
    }
}
