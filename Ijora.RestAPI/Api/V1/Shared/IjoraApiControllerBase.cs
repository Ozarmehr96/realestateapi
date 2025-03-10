using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Domain.Interactions.Auth.Queries.CheckToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ijora.RestAPI.Api.V1.Shared
{
    public abstract class IjoraApiControllerBase : ControllerBase
    {
        private const string _headerAccessToken = "Access-Token";
        private const string _headerRefreshToken = "Refresh-Token";
        private const string _headerTokenExpired = "Expires";
        private const string _authorization = "Authorization";

        public IjoraApiControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected void WriteAccessTokens(AuthAccessModel auth)
        {
            Response.Headers[_headerAccessToken] = auth.AccessToken;
            Response.Headers[_headerRefreshToken] = auth.RefreshToken;
            Response.Headers[_headerTokenExpired] = new DateTimeOffset(auth.AccessTokenExpieredAt)
                .ToUniversalTime()
                .ToUnixTimeMilliseconds()
                .ToString();
        }

        public IMediator Mediator { get; }

        protected string GetLoggerCategory(int version, string route) => $"Alrosa.RestApi.V{version}.{route}";

        protected async Task<AuthAccessModel> Autorize(CancellationToken cancellationToken = default)
        {
            if (!Request.Headers.TryGetValue(_authorization, out var authToken))
            {
                throw new AccessModelNotFoundException("Не авторизован");
            }

            AuthAccessModel auth = await Mediator.Send(new CheckTokenQuery(authToken) { ThrowIfNotFound = true });
            if (auth != null)
                WriteAuthHeader(auth);

            return auth;
        }

        protected void WriteAuthHeader(AuthAccessModel auth)
        {
            Response.Headers[_headerAccessToken] = auth.AccessToken;
            Response.Headers[_headerTokenExpired] = new DateTimeOffset(auth.AccessTokenExpieredAt)
                .ToUniversalTime()
                .ToUnixTimeMilliseconds()
                .ToString();
        }
    }
}
