

using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Неправильный номер телефона.
    /// </summary>
    public class InvalidPhoneNumberException : DomainBaseException
    {
        public InvalidPhoneNumberException(string message)
        {
            Message = message;
        }

        public new string Message { get; set; }
    }
}
