using Newtonsoft.Json;

namespace Ijora.RestAPI.Api.V1.Models
{
    [JsonObject]
    public class AuthRequest
    {
        [JsonProperty(PropertyName = "phone", Required = Required.Always)]
        public string Phone { get; set; }
    }

    [JsonObject]
    public class VerifyRequest
    {
        [JsonProperty(PropertyName = "phone", Required = Required.Always)]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "otp", Required = Required.Always)]
        public string OTP { get; set; }
    }

    [JsonObject]
    public class RefreshTokenRequest
    {
        [JsonProperty(PropertyName = "refresh_token", Required = Required.Always)]
        public string RefreshToken { get; set; }
    }

    [JsonObject]
    public class AuthResponse
    {
        /// <summary>
        /// ИД пользователя, которому принадлежит токен (только после успешной авторизации).
        /// </summary>
        [JsonProperty(PropertyName = "user", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Include)]
        public UserModelResponse? User { get; set; }

        /// <summary>
        /// Токен доступа.
        /// </summary>
        [JsonProperty(PropertyName = "access_token", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Токен обновления токена доступа.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Токен доступа.
        /// </summary>
        [JsonProperty(PropertyName = "access_token_exp_at", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public DateTime AccessTokenExpieredAt { get; set; }

        /// <summary>
        /// Токен доступа.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token_exp_at", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public DateTime RefreshTokenExpieredAt { get; set; }

        /// <summary>
        /// One Time Password - то же самое что и код
        /// Срок действия одноразового пароля.
        /// </summary>
        [JsonProperty(PropertyName = "otp", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public string OTP { get; set; }

        /// <summary>
        /// Срок действия одноразового пароля.
        /// </summary>
        [JsonProperty(PropertyName = "opt_exp_at", Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public DateTime OTPExpieredAt { get; set; }
    }
}
