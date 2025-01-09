using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ijora.RestAPI.Api.V1.Shared
{
    public abstract class IjoraApiControllerBase : ControllerBase
    {
        private const string _headerAccessToken = "Access-Token";

        /// <summary>
        /// Токен для доступа к журналам.
        /// </summary>
        private const string _headerJournalAccessToken = "Access-Token-Journal";

        /// <summary>
        /// Заголовок указывающий на выход из системы для пользователя журналов.
        /// </summary>
        private const string _headerJournalUserUnAuth = "Access-Journal-Denided";
        private const string _headerWebSocketToken = "WebSocket-Token";
        private const string _headerRefreshToken = "Refresh-Token";
        private const string _headerTokenExpired = "Expires";

        public IjoraApiControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        protected string GetLoggerCategory(int version, string route) => $"Alrosa.RestApi.V{version}.{route}";
    }
}
