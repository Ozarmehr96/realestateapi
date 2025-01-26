using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Domain.Interactions.Users.Models;
using Ijora.Storage.Entity;
using Newtonsoft.Json;

namespace Ijora.Data.Mappers
{
    public static class AuthMapper
    {
        public static AuthAccessModel ToDomainModel(this AuthEntity auth)
        {
            var userJson = JsonConvert.DeserializeObject<UserModel?>(auth.UserJson ?? string.Empty);

            return new AuthAccessModel()
            {
                Id = auth.Id,
                User = userJson,
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                AccessTokenExpieredAt = auth.AccessTokenExpieredAt,
                RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt,
                Phone = auth.Phone,
                RetryCount = auth.RetryCount,
                OTP = auth.OTP,
                OTPExpieredAt = auth.OTPExpieredAt,
            };
        }

        public static AuthEntity ToDatabaseEntity(this AuthAccessModel auth)
        {
            var userJson = JsonConvert.SerializeObject(auth.User);
            return new AuthEntity()
            {
                Id = auth.Id,
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                AccessTokenExpieredAt = auth.AccessTokenExpieredAt,
                RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt,
                Phone = auth.Phone,
                RetryCount = auth.RetryCount,
                OTP = auth.OTP,
                OTPExpieredAt = auth.OTPExpieredAt,
                UserJson = userJson
            };
        }

        public static void ApplyTo(this AuthAccessModel auth, AuthEntity e)
        {
            e.RetryCount = auth.RetryCount;
            e.AccessToken = auth.AccessToken;
            e.RefreshToken = auth.RefreshToken;
            e.AccessTokenExpieredAt = auth.AccessTokenExpieredAt;
            e.RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt;
            e.OTP = auth.OTP;
            e.OTPExpieredAt = auth.OTPExpieredAt;
            e.UserJson = auth.User is null ? null : JsonConvert.SerializeObject(auth.User);
        }
    }
}
