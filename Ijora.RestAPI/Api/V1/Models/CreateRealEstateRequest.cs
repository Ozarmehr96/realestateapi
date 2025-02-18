using Newtonsoft.Json;

namespace Ijora.RestAPI.Api.V1.Models
{
    [JsonObject]
    public class CreateRealEstateRequest
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "address", Required = Required.Always)]
        public string Address { get; set; }

        /// <summary>
        /// Количество комнат в объекте недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "room_count")]
        public int? RoomCount { get; set; }

        /// <summary>
        /// Общая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        [JsonProperty(PropertyName = "square_meters", Required = Required.Always)]
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Жилая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        [JsonProperty(PropertyName = "living_area")]
        public double? LivingArea { get; set; }

        /// <summary>
        /// Площадь кухни в объекте недвижимости в квадратных метрах.
        /// </summary>
        [JsonProperty(PropertyName = "kitchen_area")]
        public double KitchenArea { get; set; }

        /// <summary>
        /// Этаж, на котором находится объект недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "floor")]
        public int? Floor { get; set; }

        /// <summary>
        /// ИД жилого комплекса (ЖК), к которому относится дом
        /// </summary>
        public long? ComplexId { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        [JsonProperty(PropertyName = "total_floors")]
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Описание объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "description", Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>
        /// Наличие парковочного места.
        /// </summary>
        [JsonProperty(PropertyName = "has_parking")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double? Price { get; set; }

        #endregion

        #region Планировка

        /// <summary>
        /// Вид из окон объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "window_view")]
        public string WindowView { get; set; }

        /// <summary>
        /// Наличие балкона в объекте недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "has_balcony")]
        public bool HasBalcony { get; set; }

        /// <summary>
        /// Высота потолков в объекте недвижимости в метрах.
        /// </summary>
        [JsonProperty(PropertyName = "ceiling_height")]
        public double? CeilingHeight { get; set; }

        /// <summary>
        /// Количество санузлов в объекте недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "bathroom_count")]
        public int? BathroomCount { get; set; }

        #endregion

        #region Подъезд

        /// <summary>
        /// Наличие лифта в подъезде.
        /// </summary>
        [JsonProperty(PropertyName = "has_elevator")]
        public bool HasElevator { get; set; }

        /// <summary>
        /// Количество грузовых лифтов в подъезде.
        /// </summary>
        [JsonProperty(PropertyName = "cargo_elevator_count")]
        public int CargoElevatorCount { get; set; }

        #endregion

        #region Доп характеристики

        /// <summary>
        /// Тип отопления (например, Центральное, Индивидуальное).
        /// </summary>
        [JsonProperty(PropertyName = "heating_type")]
        public string? HeatingType { get; set; }

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        [JsonProperty(PropertyName = "ownership_type")]
        public string OwnershipType { get; set; }

        /// <summary>
        /// Состояние дома (новостройка, вторичка)
        /// </summary>
        [JsonProperty(PropertyName = "property_condition", Required = Required.Always)]
        public string PropertyCondition { get; set; }

        /// <summary>
        /// Дата постройки здания.
        /// </summary>
        [JsonProperty(PropertyName = "year_built")]
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Находится ли объект в закрытом жилом комплексе.
        /// </summary>
        [JsonProperty(PropertyName = "is_in_gated_community")]
        public bool IsInGatedCommunity { get; set; }

        /// <summary>
        /// Разрешены ли домашние животные.
        /// </summary>
        [JsonProperty(PropertyName = "allows_pets")]
        public bool AllowsPets { get; set; }

        /// <summary>
        /// Разрешено ли проживание с детьми.
        /// </summary>
        [JsonProperty(PropertyName = "allows_children")]
        public bool AllowsChildren { get; set; }

        /// <summary>
        /// URL-ы изображений объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "image_urls", Required = Required.Always)]
        public List<string> ImageUrls { get; set; }

        /// <summary>
        /// Наличие мебели в объекте.
        /// </summary>
        [JsonProperty(PropertyName = "is_furnished")]
        public bool IsFurnished { get; set; }

        #endregion

        #region Детали сделки

        /// <summary>
        /// Количество лет в собственности у текущего владельца.
        /// </summary>
        [JsonProperty(PropertyName = "ownership_years")]
        public int OwnershipYears { get; set; }

        /// <summary>
        /// Количество собственников объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "owner_count")]
        public int OwnerCount { get; set; }

        #endregion

        #region Данные о записи

        /// <summary>
        /// Номер телефона, с которого была опубликована запись.
        /// </summary>
        [JsonProperty(PropertyName = "publisher_phone_number")]
        public string PublisherPhoneNumber { get; set; }

        /// <summary>
        /// Тип записи (продажа или аренда).
        /// </summary>
        [JsonProperty(PropertyName = "property_usage_type", Required = Required.Always)]
        public string PropertyUsageType { get; set; }

        /// <summary>
        /// Тип недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "property_type", Required = Required.Always)]
        public string PropertyType { get; set; }

        #endregion

        #region Материал стен

        /// <summary>
        /// Материал стен здания.
        /// </summary>
        [JsonProperty(PropertyName = "wall_material")]
        public string WallMaterial { get; set; }

        #endregion

        #region Состояние ремонта

        /// <summary>
        /// Состояние ремонта объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "renovation")]
        public string Renovation { get; set; }

        #endregion
    }
}
