using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Complexes.Models;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Complexes
{
    public interface IComplexRepository : IRepository
    {
        /// <summary>
        /// Сохранение ЖК.
        /// </summary>
        /// <param name="complexModel"></param>
        /// <returns></returns>
        Task<ComplexModel> Save(ComplexModel complexModel);
    }
}
