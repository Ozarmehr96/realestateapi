using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;
using System.Collections.Generic;

namespace Ijora.Domain.Interactions.RealEstates.Queries.GetAll
{
    public class GetAllRealEstatesQuery : IRequest<List<RealEstateShortModel>>
    {
    }
}
