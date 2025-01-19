using Ijora.Domain.Interactions.Auth.Models;
using MediatR;

namespace Ijora.Domain.Interactions.Auth.Commands.Verify
{
    /// <summary>
    /// Подтверждение авторизации с помощью одноразового пароля.
    /// </summary>
    public class VerifyOTPCommand : IRequest<AuthAccessModel>
    {
        public VerifyOTPCommand(string phone, string oTP)
        {
            Phone = phone;
            OTP = oTP;
        }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Одноразовый смс код.
        /// </summary>
        public string OTP { get; set; }
    }
}
