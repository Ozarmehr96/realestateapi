using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ijora.Storage.Entity
{
    /// <summary>
    /// Представляет жилой комплекс ЖК.
    /// </summary>
    public class ComplexEntity
    {
        /// <summary>
        /// Уникальный идентификатор жилого комплекса.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название жилого комплекса.
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Описание жилого комплекса.
        /// </summary>
        [MaxLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Местоположение
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Название застройщика.
        /// </summary>
        [MaxLength(100)]
        public string Developer { get; set; }

        /// <summary>
        /// Год начала строительства.
        /// </summary>
        public int BuildYear { get; set; }

        /// <summary>
        /// Статус строительства (например, "Planned", "UnderConstruction", "Completed").
        /// </summary>
        [MaxLength(50)]
        public string ConstructionStatus { get; set; }

        /// <summary>
        /// Признак того, что жилой комплекс построен.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Год завершения строительства (если завершено).
        /// </summary>
        public int? CompletionYear { get; set; }

        /// <summary>
        /// Дата создания записи.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления записи.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// ИД сотрудника, который опубликовал
        /// </summary>
        public long PublisherUserId { get; set; }

        /// <summary>
        /// Фотографии ЖК.
        /// </summary>
        public string ImageUrls { get; set; }

        public static void OnModelConfig(EntityTypeBuilder<ComplexEntity> config)
        {
            config.HasIndex(r => new { r.Id, r.Address, r.CreatedAt });
            config.ToTable("Complexes", IjoraServiceContext.SCHEMA)
                .HasKey(a => a.Id);
        }
    }
}
