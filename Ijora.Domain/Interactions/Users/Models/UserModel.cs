using System;

namespace Ijora.Domain.Interactions.Users.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// ИД пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя (обычный или админ)
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Дата первой регистрации.
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// Дата последней авторизации.
        /// </summary>
        public DateTime LastAuthDate { get; set; }
    }
}
