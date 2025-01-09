using Ijora.Domain.Interactions.Properties;
using Ijora.Storage;

namespace Ijora.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IjoraServiceContext _dbContext;

        public PropertyRepository(IjoraServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetProperty(long id)
        {

            /// var dd = await _dbContext.Properties.ToListAsync();


            return 9;
        }
    }
}
