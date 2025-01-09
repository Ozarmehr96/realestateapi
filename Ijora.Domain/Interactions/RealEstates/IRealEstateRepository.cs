using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.RealEstates.Models;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates
{
    public interface IRealEstateRepository : IRepository
    {
        /// <summary>
        /// Сохранение недвижимости.
        /// </summary>
        /// <param name="realEstate"></param>
        /// <returns></returns>
        Task<RealEstateModel> Save(RealEstateModel realEstate);
    }
}
