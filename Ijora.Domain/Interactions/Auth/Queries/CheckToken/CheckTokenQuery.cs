using Ijora.Domain.Interactions.Auth.Models;
using MediatR;

namespace Ijora.Domain.Interactions.Auth.Queries.CheckToken
{
    /// <summary>
    /// Проверка токена на доступ.
    /// </summary>
    public class CheckTokenQuery : IRequest<AuthAccessModel>
    {
        /// <summary>
        /// Проверка токена на доступ.
        /// </summary>
        public CheckTokenQuery(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; set; }
        public bool ThrowIfNotFound { get; set; }
    }
}
