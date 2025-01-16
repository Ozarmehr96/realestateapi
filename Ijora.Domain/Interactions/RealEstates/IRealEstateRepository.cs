using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.RealEstates.Models;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates
{
    public interface IRealEstateRepository : IRepository
    {
        /// <summary>
        /// Получение недвижимости.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<RealEstateModel> Get(long Id);

        /// <summary>
        /// Сохранение недвижимости.
        /// </summary>
        /// <param name="realEstate"></param>
        /// <returns></returns>
        Task<RealEstateModel> Save(RealEstateModel realEstate);
    }
}
