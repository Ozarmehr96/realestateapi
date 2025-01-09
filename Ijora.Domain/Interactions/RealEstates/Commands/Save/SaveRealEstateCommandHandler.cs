using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates.Commands.Save
{
    public class SaveRealEstateCommandHandler : IRequestHandler<SaveRealEstateCommand, RealEstateModel>
    {
        public async Task<RealEstateModel> Handle(SaveRealEstateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
