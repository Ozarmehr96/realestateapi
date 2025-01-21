using Ijora.Domain.Interactions.Users.Models;
using Ijora.RestAPI.Api.V1.Models;

namespace Ijora.RestAPI.Api.V1.Mappers
{
    public static class UsersMapper
    {
        public static UserModelResponse ToResponse(this UserModel user)
        {
            return new UserModelResponse()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString(),
                RegistrationDateTime = user.RegistrationDateTime
            };
        }
    }
}
