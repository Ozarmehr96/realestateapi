using Ijora.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Properties
{
    public interface IPropertyRepository: IRepository
    {
        Task<int> GetProperty(long id);
    }
}
