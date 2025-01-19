using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ijora.Storage.Entity
{
    /// <summary>
    /// Авторизация.
    /// </summary>
    public class AuthEntity
    {
        /// <summary>
        /// ИД записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// ИД пользователя, которому принадлежит токен (только после успешной авторизации).
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Номер телефона необходим во время авторизации.
        /// </summary>
        [MaxLength(20)]
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
        /// Токен доступа.
        /// </summary>
        public DateTime AccessTokenExpieredAt { get; set; }

        /// <summary>
        /// Токен доступа.
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

        public static void OnModelConfig(EntityTypeBuilder<AuthEntity> config)
        {
            config.ToTable("Auth", IjoraServiceContext.SCHEMA)
                .HasKey(a => a.Id);

            config.HasIndex(r => new { r.AccessToken, r.Phone, r.UserId });
        }
    }
}
