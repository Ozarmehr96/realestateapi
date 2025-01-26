using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Auth.Queries.CheckToken
{
    /// <summary>
    /// Проверка токена на доступ.
    /// </summary>
    public class CheckTokenQueryHandler : IRequestHandler<CheckTokenQuery, AuthAccessModel>
    {
        private readonly IAuthRepository _authRepository;
        public CheckTokenQueryHandler(IRepositoryProvider provider)
        {
            _authRepository = provider.GetRepository<IAuthRepository>();
        }

        public async Task<AuthAccessModel> Handle(CheckTokenQuery request, CancellationToken cancellationToken)
        {
            var auth = await _authRepository.GetByToken(request.AccessToken);
            if (request.ThrowIfNotFound && auth is null)
                throw new AccessModelNotFoundException("Не авторизован");

            return auth;
        }
    }
}
