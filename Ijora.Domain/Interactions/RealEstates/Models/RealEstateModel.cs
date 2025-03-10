using System;
using System.Collections.Generic;

namespace Ijora.Domain.Interactions.RealEstates.Models
{
    /// <summary>
    /// Представляет объект недвижимости.
    /// </summary>
    public class RealEstateModel
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Доступность для продажи или аренды.
        /// </summary>
        public bool IsAvaliable { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        public string Address { get; set; }

        public CityModel City { get; set; }

        /// <summary>
        /// Количество комнат в объекте недвижимости.
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        /// Общая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Жилая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        public double? LivingArea { get; set; }

        /// <summary>
        /// Площадь кухни в объекте недвижимости в квадратных метрах.
        /// </summary>
        public double KitchenArea { get; set; }

        /// <summary>
        /// Этаж, на котором находится объект недвижимости.
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Описание объекта недвижимости.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Наличие парковочного места.
        /// </summary>
        public bool HasParking { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        public double? Price { get; set; }

        #endregion

        #region Планировка

        /// <summary>
        /// Вид из окон объекта недвижимости.
        /// </summary>
        public WindowViewType? WindowView { get; set; }

        /// <summary>
        /// Наличие балкона в объекте недвижимости.
        /// </summary>
        public bool HasBalcony { get; set; }

        /// <summary>
        /// Высота потолков в объекте недвижимости в метрах.
        /// </summary>
        public double? CeilingHeight { get; set; }

        /// <summary>
        /// Количество санузлов в объекте недвижимости.
        /// </summary>
        public int? BathroomCount { get; set; }

        #endregion

        #region Подъезд

        /// <summary>
        /// Наличие лифта в подъезде.
        /// </summary>
        public bool HasElevator { get; set; }

        /// <summary>
        /// Количество грузовых лифтов в подъезде.
        /// </summary>
        public int CargoElevatorCount { get; set; }

        #endregion

        #region Доп характеристики

        /// <summary>
        /// Тип отопления (например, Центральное, Индивидуальное).
        /// </summary>
        public HeatingType? HeatingType { get; set; }

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        public OwnershipType? OwnershipType { get; set; }

        /// <summary>
        /// Состояние дома (новостройка, вторичка)
        /// </summary>
        public PropertyCondition? PropertyCondition { get; set; }

        /// <summary>
        /// Дата постройки здания.
        /// </summary>
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Находится ли объект в закрытом жилом комплексе.
        /// </summary>
        public bool IsInGatedCommunity { get; set; }

        /// <summary>
        /// Разрешены ли домашние животные.
        /// </summary>
        public bool AllowsPets { get; set; }

        /// <summary>
        /// Разрешено ли проживание с детьми.
        /// </summary>
        public bool AllowsChildren { get; set; }

        /// <summary>
        /// URL-ы изображений объекта недвижимости.
        /// </summary>
        public List<string> ImageUrls { get; set; }

        /// <summary>
        /// Наличие мебели в объекте.
        /// </summary>
        public bool IsFurnished { get; set; }

        #endregion

        #region Детали сделки

        /// <summary>
        /// Количество лет в собственности у текущего владельца.
        /// </summary>
        public int OwnershipYears { get; set; }

        /// <summary>
        /// Количество собственников объекта недвижимости.
        /// </summary>
        public int OwnerCount { get; set; }

        #endregion

        #region Данные о записи

        /// <summary>
        /// Идентификатор пользователя, который разместил запись.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата публикации записи о недвижимости.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Номер телефона, с которого была опубликована запись.
        /// </summary>
        public string PublisherPhoneNumber { get; set; }

        /// <summary>
        /// ИД жилого комплекса (ЖК), к которому относится дом
        /// </summary>
        public long? ComplexId { get; set; }

        /// <summary>
        /// Тип записи (продажа или аренда).
        /// </summary>
        public PropertyUsageType PropertyUsageType { get; set; }

        /// <summary>
        /// Тип недвижимости.
        /// </summary>
        public PropertyType? PropertyType { get; set; }

        #endregion

        #region Материал стен

        /// <summary>
        /// Материал стен здания.
        /// </summary>
        public WallMaterial? WallMaterial { get; set; }

        #endregion

        #region Состояние ремонта

        /// <summary>
        /// Состояние ремонта объекта недвижимости.
        /// </summary>
        public Renovation? Renovation { get; set; }

        #endregion
    }
}
