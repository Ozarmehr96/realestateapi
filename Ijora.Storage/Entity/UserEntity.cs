using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ijora.Storage.Entity
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// ИД пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [MaxLength(200)]
        public string? UserName { get; set; }

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

        /// <summary>
        /// Дата последней авторизации.
        /// </summary>
        public DateTime LastAuthDate { get; set; }

        public static void OnModelConfig(EntityTypeBuilder<UserEntity> config)
        {
            config.ToTable("Users", IjoraServiceContext.SCHEMA)
                .HasKey(a => a.Id);

            config.HasIndex(r => r.UserId);
            config.Property(e => e.RegistrationDateTime).HasColumnType("DATETIME");
            config.Property(e => e.LastAuthDate).HasColumnType("DATETIME");
            config.Property(e => e.UserId).HasColumnType("char(36)");
        }
    }
}
