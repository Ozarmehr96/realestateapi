using Ijora.Domain.Interactions.Users.Models;
using System;

namespace Ijora.Domain.Interactions.Auth.Models
{
    /// <summary>
    /// Авторизация.
    /// </summary>
    public class AuthAccessModel
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ИД пользователя, которому принадлежит токен (только после успешной авторизации).
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Номер телефона необходим во время авторизации.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Количество попыток.
        /// </summary>
        public short RetryCount { get; set; }

        /// <summary>
        /// Токен доступа.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Токен обновления токена доступа.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Срок действия токена обновления.
        /// </summary>
        public DateTime AccessTokenExpieredAt { get; set; }

        /// <summary>
        /// Срок действия токена обновления.
        /// </summary>
        public DateTime RefreshTokenExpieredAt { get; set; }

        /// <summary>
        /// One Time Password - то же самое что и код
        /// Срок действия одноразового пароля.
        /// </summary>
        public string OTP { get; set; }

        /// <summary>
        /// Срок действия одноразового пароля.
        /// </summary>
        public DateTime OTPExpieredAt { get; set; }
    }
}
