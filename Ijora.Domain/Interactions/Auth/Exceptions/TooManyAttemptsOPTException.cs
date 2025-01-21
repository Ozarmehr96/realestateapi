using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Истек количество ввода неправильного кода подтверждения.
    /// </summary>
    public class TooManyAttemptsOPTException : DomainBaseException
    {
        public TooManyAttemptsOPTException(string message)
        {
            Message = message;
        }

        public new string Message { get; set; }
    }
}
