using Ijora.Domain.Interactions.RealEstates.Models;
using Newtonsoft.Json;
namespace Ijora.RestAPI.Api.V1.Models
{

    public class CreateRealEstateRequest
    {
        /// <summary>
        /// Тип записи: аренда, продажа.
        /// </summary>
        [JsonProperty("property_usage_type")]
        public PropertyUsageType PropertyUsageType { get; set; }

        /// <summary>
        /// Площадь объекта в квадратных метрах.
        /// </summary>
        [JsonProperty("square_meters")]
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        [JsonProperty("price")]
        public double? Price { get; set; }

        /// <summary>
        /// Тип недвижимости (например, Квартира, Дом, Таунхаус и т.д.).
        /// </summary>
        [JsonProperty("property_type")]
        public PropertyType PropertyType { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Количество комнат в объекте.
        /// </summary>
        [JsonProperty("room_count")]
        public int? RoomCount { get; set; }

        /// <summary>
        /// Этаж, на котором расположен объект (для квартир).
        /// </summary>
        [JsonProperty("floor")]
        public int? Floor { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        [JsonProperty("total_floors")]
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Наличие парковочного места.
        /// </summary>
        [JsonProperty("has_parking")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Наличие балкона или лоджии.
        /// </summary>
        [JsonProperty("has_balcony")]
        public bool HasBalcony { get; set; }

        /// <summary>
        /// Год постройки здания.
        /// </summary>
        [JsonProperty("year_built")]
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Наличие мебели в объекте.
        /// </summary>
        [JsonProperty("is_furnished")]
        public bool IsFurnished { get; set; }

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        [JsonProperty("ownership_type")]
        public OwnershipType OwnershipType { get; set; }

        /// <summary>
        /// Состояние ремонта (например, Дизайнерский, Косметический, Без ремонта).
        /// </summary>
        [JsonProperty("renovation")]
        public Renovation Renovation { get; set; }

        /// <summary>
        /// Площадь кухни в квадратных метрах.
        /// </summary>
        [JsonProperty("kitchen_area")]
        public double KitchenArea { get; set; }

        /// <summary>
        /// Жилая площадь объекта в квадратных метрах.
        /// </summary>
        [JsonProperty("living_area")]
        public double LivingArea { get; set; }

        /// <summary>
        /// Площадь земельного участка (для домов и дач) в квадратных метрах.
        /// </summary>
        [JsonProperty("land_area")]
        public double LandArea { get; set; }

        /// <summary>
        /// Материал стен здания (например, Кирпич, Панель, Монолит, Дерево и т.д.).
        /// </summary>
        [JsonProperty("wall_material")]
        public WallMaterial WallMaterial { get; set; }

        /// <summary>
        /// Находится ли объект в закрытом жилом комплексе.
        /// </summary>
        [JsonProperty("is_in_gated_community")]
        public bool IsInGatedCommunity { get; set; }

        /// <summary>
        /// Наличие лифта (для многоквартирных домов).
        /// </summary>
        [JsonProperty("has_elevator")]
        public bool HasElevator { get; set; }

        /// <summary>
        /// Разрешены ли домашние животные.
        /// </summary>
        [JsonProperty("allows_pets")]
        public bool AllowsPets { get; set; }

        /// <summary>
        /// Разрешено ли проживание с детьми.
        /// </summary>
        [JsonProperty("allows_children")]
        public bool AllowsChildren { get; set; }

        /// <summary>
        /// Подробное описание объекта недвижимости.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// URL-ы изображений объекта, сохранённые в формате JSON или через запятую.
        /// </summary>
        [JsonProperty("image_urls")]
        public List<string> ImageUrls { get; set; }
    }
}
