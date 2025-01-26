using Ijora.Domain.Interactions.Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ijora.Domain.Interactions.Auth
{
    public static class JwtTokenService
    {
        public static string GenerateToken(string phoneNumber)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aG93ZHlkYnliY2xocm5wbXRxem94YWFmZ3N2b25rcXlyc2JsaXdhZA=="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, phoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "IjoreServiceApp",
                audience: "IjoraServiceUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Инициализация токенов.
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static AuthAccessModel InitTokens(this AuthAccessModel auth, string phone)
        {
            auth.AccessToken = JwtTokenService.GenerateToken(phone);
            auth.AccessTokenExpieredAt = DateTime.Now.AddMinutes(Global.AccessTokenExpieredAtMinutes);

            auth.RefreshToken = JwtTokenService.GenerateToken(phone);
            auth.RefreshTokenExpieredAt = DateTime.Now.Date.AddDays(Global.RefreshTokenExpieredAtDays);
            return auth;
        }
    }
}
