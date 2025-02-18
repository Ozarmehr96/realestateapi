using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.RealEstates.Exceptions;
using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates.Queries.GetRealEstate
{
    /// <summary>
    /// Обработчик получения недвижимости.
    /// </summary>
    public class GetRealEstateQueryHandler : IRequestHandler<GetRealEstateQuery, RealEstateModel>
    {
        private readonly IRealEstateRepository _realEstateRepository;
        public GetRealEstateQueryHandler(IRepositoryProvider provider)
        {
            _realEstateRepository = provider.GetRepository<IRealEstateRepository>();
        }

        public async Task<RealEstateModel> Handle(GetRealEstateQuery request, CancellationToken cancellationToken)
        {
            var realEstate = await _realEstateRepository.Get(request.Id);
            if (realEstate is null)
                throw new RealEstateNotFoundException();

            return realEstate;
        }
    }
}
