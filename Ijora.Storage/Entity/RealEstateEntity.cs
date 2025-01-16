using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ijora.Storage.Entity
{
    public class RealEstateEntity
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Доступность для продажи или аренды.
        /// </summary>
        public bool IsAvaliable { get; set; }

        /// <summary>
        /// ИД сотрудника, который разместил объявление.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата публикации записи о недвижимости.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Номер телефона, с которого была опубликована запись.
        /// </summary>
        [MaxLength(50)]
        public string? PublisherPhoneNumber { get; set; }

        /// <summary>
        /// ИД жилого комплекса (ЖК), к которому относится дом
        /// </summary>
        public long? ComplexId { get; set; }

        /// <summary>
        /// Вид из окон объекта недвижимости.
        /// </summary>
        [MaxLength(50)]
        public string? WindowView { get; set; }

        /// <summary>
        /// Тип недвижимости: аренда, продажа.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string PropertyUsageType { get; set; }

        /// <summary>
        /// Площадь объекта в квадратных метрах.
        /// </summary>
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Тип недвижимости (например, Квартира, Дом, Таунхаус и т.д.).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PropertyType { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        #endregion

        #region Планировка

        /// <summary>
        /// Количество комнат в объекте.
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        /// Этаж, на котором расположен объект (для квартир).
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Наличие парковочного места.
        /// </summary>
        public bool HasParking { get; set; }

        /// <summary>
        /// Наличие балкона или лоджии.
        /// </summary>
        public bool HasBalcony { get; set; }

        /// <summary>
        /// Год постройки здания.
        /// </summary>
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Тип отопления (например, Центральное, Индивидуальное).
        /// </summary>
        [MaxLength(50)]
        public string? HeatingType { get; set; }

        /// <summary>
        /// Наличие мебели в объекте.
        /// </summary>
        public bool IsFurnished { get; set; }

        #endregion

        #region Состояние объекта

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string? OwnershipType { get; set; }

        /// <summary>
        /// Состояние ремонта (например, Дизайнерский, Косметический, Без ремонта).
        /// </summary>
        [MaxLength(50)]
        public string? Renovation { get; set; }

        /// <summary>
        /// Площадь кухни в квадратных метрах.
        /// </summary>
        public double KitchenArea { get; set; }

        /// <summary>
        /// Жилая площадь объекта в квадратных метрах.
        /// </summary>
        public double? LivingArea { get; set; }

        /// <summary>
        /// Материал стен здания (например, Кирпич, Панель, Монолит, Дерево и т.д.).
        /// </summary>
        [MaxLength(50)]
        public string? WallMaterial { get; set; }

        #endregion

        #region Дополнительные характеристики

        /// <summary>
        /// Находится ли объект в закрытом жилом комплексе.
        /// </summary>
        public bool IsInGatedCommunity { get; set; }

        /// <summary>
        /// Наличие лифта (для многоквартирных домов).
        /// </summary>
        public bool HasElevator { get; set; }

        /// <summary>
        /// Разрешены ли домашние животные.
        /// </summary>
        public bool AllowsPets { get; set; }

        /// <summary>
        /// Разрешено ли проживание с детьми.
        /// </summary>
        public bool AllowsChildren { get; set; }

        /// <summary>
        /// Подробное описание объекта недвижимости.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL-ы изображений объекта, сохранённые в формате JSON или через запятую.
        /// </summary>
        public string ImageUrls { get; set; }

        /// <summary>
        /// Количество санузлов в объекте недвижимости.
        /// </summary>
        public int? BathroomCount { get; set; }

        /// <summary>
        /// Количество грузовых лифтов в подъезде.
        /// </summary>
        public int CargoElevatorCount { get; set; }

        /// <summary>
        /// Высота потолков в объекте недвижимости в метрах.
        /// </summary>
        public double? CeilingHeight { get; set; }

        #endregion

        #region Детали собственности

        /// <summary>
        /// Количество собственников объекта недвижимости.
        /// </summary>
        public int OwnerCount { get; set; }

        /// <summary>
        /// Количество лет в собственности у текущего владельца.
        /// </summary>
        public int OwnershipYears { get; set; }

        #endregion

        #region Состояние дома

        /// <summary>
        /// Состояние дома (новостройка, вторичка)
        /// </summary>
        [MaxLength(50)]
        public string? PropertyCondition { get; set; }

        #endregion

        public static void OnModelConfig(EntityTypeBuilder<RealEstateEntity> config)
        {
            config.HasIndex(r => new { r.Id, r.Address });
            config.ToTable("RealEstates", IjoraServiceContext.SCHEMA)
                .HasKey(a => a.Id);
        }
    }

}
