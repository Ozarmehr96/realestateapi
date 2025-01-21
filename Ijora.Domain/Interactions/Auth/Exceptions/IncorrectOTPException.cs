using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Неправильный одноразовый пароль (OTP).
    /// </summary>
    public class IncorrectOTPException : DomainBaseException
    {
    }
}
