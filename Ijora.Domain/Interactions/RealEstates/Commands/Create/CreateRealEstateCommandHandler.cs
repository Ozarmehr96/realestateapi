using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates.Commands.Create
{
    public class CreateRealEstateCommandHandler : IRequestHandler<CreateRealEstateCommand, RealEstateModel>
    {
        private readonly IRealEstateRepository _realEstateRepository;
        public CreateRealEstateCommandHandler(IRepositoryProvider provider)
        {
            _realEstateRepository = provider.GetRepository<IRealEstateRepository>();
        }

        public async Task<RealEstateModel> Handle(CreateRealEstateCommand request, CancellationToken cancellationToken)
        {
            // Todo: Проверка уникальности недвижимости

            var realEstate = new RealEstateModel()
            {
                Address = request.
            };
        }
    }
}
