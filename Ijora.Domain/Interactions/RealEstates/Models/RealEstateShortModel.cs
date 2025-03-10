using System;

namespace Ijora.Domain.Interactions.RealEstates.Models
{
    /// <summary>
    /// Недвижимость.
    /// </summary>
    public class RealEstateShortModel
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Это VIP объявление.
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Количество комнат в объекте недвижимости.
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        /// Общая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Этаж, на котором находится объект недвижимости.
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>

        public string Image { get; set; }
        #endregion

        public CityModel City { get; set; }

        /// <summary>
        /// Доступность для продажи или аренды.
        /// </summary>
        public bool IsAvaliable { get; set; }

        /// <summary>
        /// Дата публикации записи о недвижимости.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Тип недвижимости (продажа, аренда)
        /// </summary>
        public PropertyUsageType PropertyUsageType { get; set; }

        /// <summary>
        /// Тип недвижимости/постройки (Квартира/Дом/Таунхаус)
        /// </summary>
        public PropertyType PropertyType { get; set; }
    }
}
