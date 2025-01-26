using Ijora.Data.Mappers;
using Ijora.Domain.Interactions.Users;
using Ijora.Domain.Interactions.Users.Models;
using Ijora.Storage;
using Microsoft.EntityFrameworkCore;

namespace Ijora.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public UsersRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> GetUserByPhone(string phone)
        {
            var userEntity = await _dbContext.Users.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.PhoneNumber == phone);

            return userEntity?.ToDomainModel();
        }

        public async Task<UserModel> Save(UserModel user)
        {
            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (userEntity is null)
                _dbContext.Users.Add(user.ToDatabaseEntity());
            else
                user.ApplyTo(userEntity);

            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
