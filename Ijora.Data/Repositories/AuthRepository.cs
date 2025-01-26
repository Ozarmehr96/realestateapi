using Ijora.Data.Mappers;
using Ijora.Domain.Interactions.Auth;
using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Storage;
using Microsoft.EntityFrameworkCore;

namespace Ijora.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public AuthRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Remove(long id)
        {
            var auth = await _dbContext.Auth.FirstOrDefaultAsync(a => a.Id == id);
            if (auth is null)
                return;

            _dbContext.Auth.Remove(auth);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AuthAccessModel> Get(string phone, string otp)
        {
            var auth = await _dbContext.Auth.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Phone == phone && a.OTP == otp);

            return auth?.ToDomainModel();
        }

        public async Task<AuthAccessModel> Get(string phone)
        {
            var auth = await _dbContext.Auth.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Phone == phone);
            if (auth != null)
            {

            }
            return auth?.ToDomainModel();
        }

        public async Task<AuthAccessModel> Save(AuthAccessModel authAccessModel)
        {
            var authEntity = await _dbContext.Auth.FirstOrDefaultAsync(a =>
                    a.Id == authAccessModel.Id || a.Phone == authAccessModel.Phone);

            if (authEntity is null)
                _dbContext.Auth.Add(authAccessModel.ToDatabaseEntity());
            else
            {
                authAccessModel.ApplyTo(authEntity);
            }

            await _dbContext.SaveChangesAsync();
            return authAccessModel;
        }

        public async Task<AuthAccessModel> GetByToken(string token)
        {
            var auth = await _dbContext.Auth.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccessToken == token);

            return auth?.ToDomainModel();
        }

        public async Task<AuthAccessModel> GetByRefreshToken(string refreshToken)
        {
            var auth = await _dbContext.Auth.AsNoTracking()
                .FirstOrDefaultAsync(a => a.RefreshToken == refreshToken);

            return auth?.ToDomainModel();
        }
    }
}
