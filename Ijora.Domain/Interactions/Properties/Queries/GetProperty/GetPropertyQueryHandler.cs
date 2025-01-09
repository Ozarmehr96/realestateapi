using Ijora.Domain.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Properties.Queries.GetProperty
{
    public class GetPropertyQueryHandler : IRequestHandler<GetPropertyQuery, int>
    {
        private readonly IPropertyRepository _propertyRepository;
        public GetPropertyQueryHandler(IRepositoryProvider provider)
        {
            _propertyRepository = provider.GetRepository<IPropertyRepository>();
        }

        public async Task<int> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            return await _propertyRepository.GetProperty(request.Id);
        }
    }
}
