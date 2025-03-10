using Ijora.Domain.Interactions.RealEstates.Models;
using Newtonsoft.Json;

namespace Ijora.RestAPI.Api.V1.Models
{
    [JsonObject]
    public class RealEstateShortResponse
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Include)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "is_vip", NullValueHandling = NullValueHandling.Include)]
        public bool IsVip { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Include)]
        public string Address { get; set; }

        /// <summary>
        /// ИД города.
        /// </summary>
        [JsonProperty(PropertyName = "city_id", NullValueHandling = NullValueHandling.Include)]
        public long CityId { get; set; }

        /// <summary>
        /// ИД города.
        /// </summary>
        [JsonProperty(PropertyName = "city_name", NullValueHandling = NullValueHandling.Include)]
        public string CityName { get; set; }

        /// <summary>
        /// Количество комнат в объекте недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "room_count", NullValueHandling = NullValueHandling.Include)]
        public int? RoomCount { get; set; }

        /// <summary>
        /// Общая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        [JsonProperty(PropertyName = "square_meters", NullValueHandling = NullValueHandling.Include)]
        public double? SquareMeters { get; set; }

        /// <summary>
        /// Этаж, на котором находится объект недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "floor", NullValueHandling = NullValueHandling.Include)]
        public int? Floor { get; set; }

        /// <summary>
        /// Общее количество этажей в здании.
        /// </summary>
        [JsonProperty(PropertyName = "total_floors", NullValueHandling = NullValueHandling.Include)]
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Include)]
        public double? Price { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>

        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Include)]
        public string Image { get; set; }
        #endregion
    }

    [JsonObject]
    public class RealEstateResponse
    {
        #region Основные характеристики

        /// <summary>
        /// Уникальный идентификатор объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Полный адрес объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Количество комнат в объекте недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "room_count")]
        public int? RoomCount { get; set; }

        /// <summary>
        /// Общая площадь объекта недвижимости в квадратных метрах.
        /// </summary>
        [JsonProperty(PropertyName = "square_meters")]
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
        /// Общее количество этажей в здании.
        /// </summary>
        [JsonProperty(PropertyName = "total_floors")]
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Описание объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Наличие парковочного места.
        /// </summary>
        [JsonProperty(PropertyName = "has_parking")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Стоимость объекта недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
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
        public string HeatingType { get; set; }

        /// <summary>
        /// Тип собственности (например, Частная, Государственная).
        /// </summary>
        [JsonProperty(PropertyName = "ownership_type")]
        public string OwnershipType { get; set; }

        /// <summary>
        /// Состояние дома (новостройка, вторичка)
        /// </summary>
        [JsonProperty(PropertyName = "property_condition")]
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
        [JsonProperty(PropertyName = "image_urls")]
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
        /// Идентификатор пользователя, который разместил запись.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата публикации записи о недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "publication_date")]
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Номер телефона, с которого была опубликована запись.
        /// </summary>
        [JsonProperty(PropertyName = "publisher_phone_number")]
        public string PublisherPhoneNumber { get; set; }

        /// <summary>
        /// Тип записи (продажа или аренда).
        /// </summary>
        [JsonProperty(PropertyName = "property_usage_type")]
        public string PropertyUsageType { get; set; }

        /// <summary>
        /// Тип недвижимости.
        /// </summary>
        [JsonProperty(PropertyName = "property_type")]
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

    public static class RealEstateModelExtensions
    {
        /// <summary>
        /// Преобразует модель недвижимости в ответ, который будет возвращён клиенту.
        /// </summary>
        /// <param name="realEstate">Объект модели недвижимости.</param>
        /// <returns>Ответ для клиента в виде объекта RealEstateResponse.</returns>
        public static RealEstateShortResponse ToResponseShort(this RealEstateShortModel realEstate)
        {
            return new RealEstateShortResponse()
            {
                Id = realEstate.Id,
                Address = realEstate.Address,
                RoomCount = realEstate.RoomCount,
                SquareMeters = realEstate.SquareMeters,
                Floor = realEstate.Floor,
                TotalFloors = realEstate.TotalFloors,
                Price = realEstate.Price,
                Image = realEstate.Image
            };
        }

        public static RealEstateResponse ToResponse(this RealEstateModel realEstate)
        {
            return new RealEstateResponse
            {
                Id = realEstate.Id,
                Address = realEstate.Address,
                RoomCount = realEstate.RoomCount,
                SquareMeters = realEstate.SquareMeters,
                LivingArea = realEstate.LivingArea,
                KitchenArea = realEstate.KitchenArea,
                Floor = realEstate.Floor,
                TotalFloors = realEstate.TotalFloors,
                Description = realEstate.Description,
                HasParking = realEstate.HasParking,
                Price = realEstate.Price,
                WindowView = realEstate.WindowView?.ToString(), // Assuming WindowView is an enum
                HasBalcony = realEstate.HasBalcony,
                CeilingHeight = realEstate.CeilingHeight,
                BathroomCount = realEstate.BathroomCount,
                HasElevator = realEstate.HasElevator,
                CargoElevatorCount = realEstate.CargoElevatorCount,
                HeatingType = realEstate.HeatingType?.ToString(), // Assuming HeatingType is an enum
                OwnershipType = realEstate.OwnershipType?.ToString(), // Assuming OwnershipType is an enum
                PropertyCondition = realEstate.PropertyCondition?.ToString(), // Assuming PropertyCondition is an enum
                YearBuilt = realEstate.YearBuilt,
                IsInGatedCommunity = realEstate.IsInGatedCommunity,
                AllowsPets = realEstate.AllowsPets,
                AllowsChildren = realEstate.AllowsChildren,
                ImageUrls = realEstate.ImageUrls,
                IsFurnished = realEstate.IsFurnished,
                OwnershipYears = realEstate.OwnershipYears,
                OwnerCount = realEstate.OwnerCount,
                UserId = realEstate.UserId,
                PublicationDate = realEstate.PublicationDate,
                PublisherPhoneNumber = realEstate.PublisherPhoneNumber,
                PropertyUsageType = realEstate.PropertyUsageType.ToString(), // Assuming PropertyUsageType is an enum
                PropertyType = realEstate.PropertyType?.ToString(), // Assuming PropertyType is an enum
                WallMaterial = realEstate.WallMaterial?.ToString(), // Assuming WallMaterial is an enum
                Renovation = realEstate.Renovation?.ToString() // Assuming Renovation is an enum
            };
        }
    }
}
