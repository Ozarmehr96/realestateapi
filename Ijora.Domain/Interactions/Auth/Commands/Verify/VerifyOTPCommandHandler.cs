using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Domain.Interactions.Users.Commands.Create;
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
        private IMediator _mediator;

        public VerifyOTPCommandHandler(IRepositoryProvider provider, IMediator mediator)
        {
            _authRepository = provider.GetRepository<IAuthRepository>();
            _mediator = mediator;
        }

        public async Task<AuthAccessModel> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            // Существование записи с номером телефона.
            var auth = await _authRepository.Get(request.Phone);
            if (auth is null)
                throw new Exception("Сначала укажите номер телефона для получения код авторизации");

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

            // Соответствие кода.
            if (auth.OTP != request.OTP)
            {
                auth.RetryCount += 1;
                await _authRepository.Save(auth);
                throw new IncorrectOTPException("Неправильный код");
            }

            // инициализация токенов
            auth.InitTokens(request.Phone);
            auth.OTP = String.Empty;

            // тут же надо хранить пользователя в БД, в список пользователей
            // нужно проверить, если он в БД. Если есть, то нужно просто присвоить к auth, и вернуть 
            // если пользователя нет, то добавить в БД, и потом уже вернуть 
            var user = await _mediator.Send(new CreateUserCommand(null, Users.Models.UserRole.Common, request.Phone));
            auth.User = user;
            await _authRepository.Save(auth);

            return auth;
        }
    }
}
