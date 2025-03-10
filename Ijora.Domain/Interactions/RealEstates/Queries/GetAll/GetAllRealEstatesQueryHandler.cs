using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.RealEstates.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.RealEstates.Queries.GetAll
{
    public class GetAllRealEstatesQueryHandler : IRequestHandler<GetAllRealEstatesQuery, List<RealEstateShortModel>>
    {
        private readonly IRealEstateRepository _realEstateRepository;
        public GetAllRealEstatesQueryHandler(IRepositoryProvider provider)
        {
            _realEstateRepository = provider.GetRepository<IRealEstateRepository>();
        }

        public async Task<List<RealEstateShortModel>> Handle(GetAllRealEstatesQuery request, CancellationToken cancellationToken)
        {
            var items = new List<RealEstateShortModel>();
            bool isVip = false;
            for (int i = 1; i <= 10; i++)
            {
                items.Add(new RealEstateShortModel()
                {
                    Id = 10000 + i,
                    Address = $"13 мкр, {1 + i} дом, {70 + i} кв",
                    Image = "https://avatars.mds.yandex.net/i?id=0d14cdce188f585b7da59994445cad93_l-6371080-images-thumbs&n=13",
                    Floor = 1 + i,
                    City = new CityModel()
                    {
                        Id = 1,
                        Name = "Худжанд"
                    },
                    IsAvaliable = true,
                    Price = (i * 100000) + 50000,
                    PropertyType = PropertyType.Apartment,
                    PropertyUsageType = PropertyUsageType.Sale,
                    PublicationDate = DateTime.Now,
                    RoomCount = 3,
                    SquareMeters = 70 + i,
                    TotalFloors = 12,
                    IsVip = isVip,
                });
                isVip = !isVip;
            }
            return items;
            return await _realEstateRepository.GetAll();
        }
    }
}
