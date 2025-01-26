using Ijora.Domain.Interactions.Users.Models;
using MediatR;

namespace Ijora.Domain.Interactions.Users.Commands.Create
{

    /// <summary>
    /// Создание пользователя.
    /// </summary>
    public class CreateUserCommand : IRequest<UserModel>
    {
        public CreateUserCommand(string userName, UserRole role, string phoneNumber)
        {
            UserName = userName;
            Role = role;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Роль пользователя (обычный или админ)
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
