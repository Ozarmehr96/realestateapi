using Newtonsoft.Json;

namespace Ijora.RestAPI.Api.V1.Models
{
    [JsonObject]
    public class UserModelResponse
    {
        /// <summary>
        /// ИД пользователя.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Include, Required = Required.Always)]
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Include, Required = Required.AllowNull)]
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя (обычный или админ)
        /// </summary>
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Include, Required = Required.Always)]
        public string Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Include, Required = Required.Always)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Дата первой регистрации.
        /// </summary>
        [JsonProperty(PropertyName = "registration_datetime", NullValueHandling = NullValueHandling.Include, Required = Required.Always)]
        public DateTime RegistrationDateTime { get; set; }
    }
}
