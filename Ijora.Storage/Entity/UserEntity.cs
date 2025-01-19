using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ijora.Storage.Entity
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// ИД пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [MaxLength(200)]
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя (обычный или админ)
        /// </summary>
        [MaxLength(59)]
        public string Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Дата первой регистрации.
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        public static void OnModelConfig(EntityTypeBuilder<UserEntity> config)
        {
            config.HasIndex(r => r.UserId);
            config.ToTable("Users", IjoraServiceContext.SCHEMA)
                .HasKey(a => a.UserId);
        }
    }
}
