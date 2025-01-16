using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;

namespace Ijora.Domain.Interactions.RealEstates.Queries.GetRealEstate
{
    public class GetRealEstateQuery : IRequest<RealEstateModel>
    {
        /// <summary>
        /// ИД недвижимости.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Получение недвижимости.
        /// </summary>
        /// <param name="id"></param>
        public GetRealEstateQuery(long id)
        {
            Id = id;
        }
    }
}
