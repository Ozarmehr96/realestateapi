using Ijora.Domain.Interactions.Auth.Models;
using MediatR;

namespace Ijora.Domain.Interactions.Auth.Commands.Auth
{
    /// <summary>
    /// Авторизация по номеру телефона. Отправляет смс на телефон.
    /// </summary>
    public class AuthCommand : IRequest<AuthAccessModel>
    {
        public string Phone { get; set; }

        public AuthCommand(string phone)
        {
            Phone = phone;
        }
    }
}
