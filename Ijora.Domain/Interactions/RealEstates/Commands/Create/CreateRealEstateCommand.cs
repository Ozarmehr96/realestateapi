using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;

namespace Ijora.Domain.Interactions.RealEstates.Commands.Create
{
    public class CreateRealEstateCommand : IRequest<RealEstateModel>
    {
        public CreateRealEstateCommand(RealEstateModel realEstate) 
        {
            RealEstate = realEstate;
        }

        public RealEstateModel RealEstate { get; set; }
    }
}
