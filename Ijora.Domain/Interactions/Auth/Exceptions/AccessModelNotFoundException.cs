using Ijora.Domain.Infrastructure;

namespace Ijora.Domain.Interactions.Auth.Exceptions
{
    /// <summary>
    /// Не авторизован.
    /// </summary>
    public class AccessModelNotFoundException : DomainBaseException
    {
        /// <summary>
        /// Не авторизован.
        /// </summary>
        /// <param name="message"></param>
        public AccessModelNotFoundException(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Не авторизован.
        /// </summary>
        /// <param name="message"></param>
        public AccessModelNotFoundException()
        {
        }

        public new string Message { get; set; }
    }
}
