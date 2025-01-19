using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Время жизни одноразового пароля истек.
    /// </summary>
    public class OTPExpieredException : DomainBaseException
    {
        public OTPExpieredException(string message)
        {
            Message = message;
        }

        public new string Message { get; set; }
    }
}
