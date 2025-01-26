using Ijora.Domain.Interactions.Auth.Models;
using MediatR;

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
    public class RefreshTokenCommand : IRequest<AuthAccessModel>
    {
        public RefreshTokenCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; set; }
    }
}
