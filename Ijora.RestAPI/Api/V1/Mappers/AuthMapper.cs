using Ijora.Domain.Interactions.Auth.Models;
using Ijora.RestAPI.Api.V1.Models;

namespace Ijora.RestAPI.Api.V1.Mappers
{
    public static class AuthMapper
    {
        public static AuthResponse ToResponse(this AuthAccessModel auth)
        {
            return new AuthResponse()
            {
                User = auth.User?.ToResponse(),
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                AccessTokenExpieredAt = auth.AccessTokenExpieredAt,
                RefreshTokenExpieredAt = auth.RefreshTokenExpieredAt,
                OTP = auth.OTP,
                OTPExpieredAt = auth.OTPExpieredAt
            };
        }
    }
}
