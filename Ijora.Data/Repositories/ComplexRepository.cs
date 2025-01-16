using Ijora.Domain.Interactions.Complexes;
using Ijora.Domain.Interactions.Complexes.Models;
using Ijora.Storage;

namespace Ijora.Data.Repositories
{
    public class ComplexRepository : IComplexRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public ComplexRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ComplexModel> Save(ComplexModel complexModel)
        {
            //await _dbContext.Complexes.AddAsync(complexModel);
            await _dbContext.SaveChangesAsync();

            return complexModel;
        }
    }
}
