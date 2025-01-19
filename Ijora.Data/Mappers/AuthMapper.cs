using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Storage.Entity;

namespace Ijora.Data.Mappers
{
    public static class AuthMapper
    {
        public static AuthAccessModel ToDomainModel(this AuthEntity auth)
        {
            return new AuthAccessModel()
            {
                Id = auth.Id,
                User = new Domain.Interactions.Users.Models.UserModel()
                {
                    UserId = auth.UserId ?? Guid.Empty
                },
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                AccessTokenExpieredAt = auth.AccessTokenExpieredAt,
                RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt,
                Phone = auth.Phone,
                RetryCount = auth.RetryCount,
                OTP = auth.OTP,
                OTPExpieredAt = auth.OTPExpieredAt
            };
        }

        public static AuthEntity ToDatabaseEntity(this AuthAccessModel auth)
        {
            return new AuthEntity()
            {
                Id = auth.Id,
                UserId = auth?.User?.UserId,
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                AccessTokenExpieredAt = auth.AccessTokenExpieredAt,
                RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt,
                Phone = auth.Phone,
                RetryCount = auth.RetryCount,
                OTP = auth.OTP,
                OTPExpieredAt = auth.OTPExpieredAt
            };
        }

        public static void ApplyTo(this AuthAccessModel auth, AuthEntity e)
        {
            e.RetryCount = auth.RetryCount;
            e.UserId = auth.User.UserId;
            e.AccessToken = auth.AccessToken;
            e.RefreshToken = auth.RefreshToken;
            e.AccessTokenExpieredAt = auth.AccessTokenExpieredAt;
            e.RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt;
            e.OTP = auth.OTP;
            e.OTPExpieredAt = auth.OTPExpieredAt;
        }
    }
}
