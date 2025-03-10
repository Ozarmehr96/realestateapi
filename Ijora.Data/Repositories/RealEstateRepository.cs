using Ijora.Data.Mappers;
using Ijora.Domain.Interactions.RealEstates;
using Ijora.Domain.Interactions.RealEstates.Models;
using Ijora.Storage;
using Microsoft.EntityFrameworkCore;

namespace Ijora.Data.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public RealEstateRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RealEstateModel> Get(long Id)
        {
            var realEstate = await _dbContext.RealEstates.AsNoTracking().FirstOrDefaultAsync(r => r.Id == Id);
            return realEstate?.ToDomainModel();
        }

        public async Task<List<RealEstateShortModel>> GetAll()
        {
            var realEstate = await _dbContext.RealEstates.AsNoTracking().ToListAsync();
            return realEstate?.Select(t => t.ToDomainShortModel()).ToList();
        }

        public async Task<RealEstateModel> Save(RealEstateModel realEstate)
        {
            await _dbContext.RealEstates.AddAsync(realEstate.ToDatabaseEntity());
            await _dbContext.SaveChangesAsync();
            return realEstate;
        }
    }
}
