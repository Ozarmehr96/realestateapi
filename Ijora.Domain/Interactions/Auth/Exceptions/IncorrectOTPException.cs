using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Неправильный одноразовый пароль (OTP).
    /// </summary>
    public class IncorrectOTPException : DomainBaseException
    {
        public IncorrectOTPException(string message)
        {
            Message = message;
        }

        public new string Message { get; set; }
    }
}
