using Ijora.Data.Mappers;
using Ijora.Domain.Interactions.RealEstates;
using Ijora.Domain.Interactions.RealEstates.Models;
using Ijora.Storage;

namespace Ijora.Data.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public RealEstateRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RealEstateModel> Save(RealEstateModel realEstate)
        {
            await _dbContext.RealEstates.AddAsync(realEstate.ToDatabaseEntity());
            await _dbContext.SaveChangesAsync();
            return realEstate;
        }
    }
}
