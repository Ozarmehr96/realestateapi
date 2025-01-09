using System;
using System.Collections.Generic;

namespace Ijora.Domain.Interactions.RealEstates.Models
{
    /// <summary>
    /// Недвижимость.
    /// </summary>
    public class RealEstateModel
    {
        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ИД сотрудника, который разместил объявление.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата размещения объявления.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Тип записи: аренда, продажа.
        /// </summary>
        public PropertyUsageType PropertyUsageType { get; set; }

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
        public PropertyType PropertyType { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        public string Address { get; set; }

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
        /// Наличие мебели в объекте.
        /// </summary>
        public bool IsFurnished { get; set; }

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        public OwnershipType OwnershipType { get; set; }

        /// <summary>
        /// Состояние ремонта (например, Дизайнерский, Косметический, Без ремонта).
        /// </summary>
        public Renovation Renovation { get; set; }

        /// <summary>
        /// Площадь кухни в квадратных метрах.
        /// </summary>
        public double KitchenArea { get; set; }

        /// <summary>
        /// Жилая площадь объекта в квадратных метрах.
        /// </summary>
        public double LivingArea { get; set; }

        /// <summary>
        /// Площадь земельного участка (для домов и дач) в квадратных метрах.
        /// </summary>
        public double LandArea { get; set; }

        /// <summary>
        /// Материал стен здания (например, Кирпич, Панель, Монолит, Дерево и т.д.).
        /// </summary>
        public WallMaterial WallMaterial { get; set; }

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
        public List<string> ImageUrls { get; set; }
    }
}
