using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using MediatR;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Auth.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthAccessModel>
    {
        private readonly IAuthRepository _authRepository;
        public AuthCommandHandler(IRepositoryProvider provider)
        {
            _authRepository = provider.GetRepository<IAuthRepository>();
        }

        public async Task<AuthAccessModel> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            // проверяем номер телефона
            if (!Regex.IsMatch(request.Phone, @"^\+992\d{9}$"))
            {
                throw new InvalidPhoneNumberException("Неправильный номер телефона");
            }

            var otp = OtpGenerator.GenerateOtp();
            // ToDo- отправка кода по sms


            // сохраняем одноразовый пароль скрок действия которого 1 минута.
            var newAuthAccessModel = new AuthAccessModel()
            {
                Phone = request.Phone,
                OTP = otp,
                OTPExpieredAt = DateTime.Now.AddMinutes(3),
            };

            var authAccessModel = await _authRepository.Get(request.Phone);
            if (authAccessModel != null)
            {
                authAccessModel.OTP = newAuthAccessModel.OTP;
                authAccessModel.OTPExpieredAt = DateTime.Now.AddMinutes(3);
            }
            else
                authAccessModel = newAuthAccessModel;

            authAccessModel.RetryCount = 0; // сбрасываем количество ввода. В будущем еще нужно учесть и ИД устройства с котого происходит авторизация
            await _authRepository.Save(authAccessModel);

            // в целом тут ничего ввернуть и не нужно, если все ок. Но, для тестирования вернем код который отправили на телефон
            return new AuthAccessModel()
            {
                OTP = authAccessModel.OTP,
                OTPExpieredAt = authAccessModel.OTPExpieredAt
            };
        }
    }
}
