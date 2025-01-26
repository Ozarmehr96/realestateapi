using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Auth.Commands.RefreshToken
{
    /// <summary>
    /// Команда обновление токена доступа.
    /// 
    /// Сценария работы:
    /// Клиент делает запрос с токеном доступа.
    /// Если токен действителен — сервер обрабатывает запрос.
    /// Если токен недействителен (истёк или отозван), сервер возвращает 401 Unauthorized.
    /// Клиент, получив 401, отправляет запрос на обновление токена с использованием токена обновления.
    /// Если токен обновления действителен, сервер возвращает новый токен доступа.
    /// Клиент повторяет первоначальный запрос с новым токеном.
    /// </summary>
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthAccessModel>
    {
        private readonly IAuthRepository _authRepository;
        public RefreshTokenCommandHandler(IRepositoryProvider provider)
        {
            _authRepository = provider.GetRepository<IAuthRepository>();
        }

        public async Task<AuthAccessModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var auth = await _authRepository.GetByRefreshToken(request.RefreshToken);
            if (auth is null || auth.RefreshTokenExpieredAt < System.DateTime.Now)
                throw new AccessModelNotFoundException();

            auth.InitTokens(auth.Phone);
            await _authRepository.Save(auth);
            return auth;
        }
    }
}
