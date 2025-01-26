using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.Users.Models;
using Ijora.Storage.Entity;

namespace Ijora.Data.Mappers
{
    public static class UsersMapper
    {
        public static UserModel ToDomainModel(this UserEntity user)
        {
            return new UserModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                RegistrationDateTime = user.RegistrationDateTime,
                Role = (UserRole)EnumExtensions.ConvertToEnum<UserRole>(user.Role)
            };
        }

        public static UserEntity ToDatabaseEntity(this UserModel user)
        {
            return new UserEntity()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                RegistrationDateTime = user.RegistrationDateTime,
                Role = user.Role.ToString()
            };
        }

        public static void ApplyTo(this UserModel user, UserEntity entity)
        {
            entity.LastAuthDate = user.LastAuthDate;
        }
    }
}
