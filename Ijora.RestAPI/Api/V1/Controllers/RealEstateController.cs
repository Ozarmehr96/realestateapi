using Ijora.Domain.Interactions;
using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Domain.Interactions.RealEstates.Commands.Create;
using Ijora.Domain.Interactions.RealEstates.Models;
using Ijora.Domain.Interactions.RealEstates.Queries.GetAll;
using Ijora.RestAPI.Api.V1.Models;
using Ijora.RestAPI.Api.V1.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ijora.RestAPI.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/re")]
    [Produces("application/json")]
    public class RealEstateController : IjoraApiControllerBase
    {
        public RealEstateController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Mediator.Send(new GetAllRealEstatesQuery());
            return Ok(items.Select(r => r.ToResponseShort()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRealEstateRequest command, CancellationToken cancellationToken)
        {
            AuthAccessModel auth;
            try
            {
                auth = await Autorize(cancellationToken);
            }
            catch (AccessModelNotFoundException)
            {
                // return Unauthorized(ErrorText.UNAUTHORIZED.AsResponseModel());
            }

            var realEstate = await Mediator.Send(new CreateRealEstateCommand(new RealEstateModel()
            {
                AllowsChildren = command.AllowsChildren,
                Address = command.Address,
                AllowsPets = command.AllowsPets,
                BathroomCount = command.BathroomCount,
                CargoElevatorCount = command.CargoElevatorCount,
                CeilingHeight = command.CeilingHeight,
                ComplexId = command.ComplexId,
                Description = command.Description,
                Floor = command.Floor,
                HasBalcony = command.HasBalcony,
                HasElevator = command.HasElevator,
                HeatingType = EnumExtensions.ConvertToEnum<HeatingType>(command.HeatingType),
                HasParking = command.HasParking,
                //ImageUrls = command.ImageUrls,
                ImageUrls = command.ImageUrls,
                IsFurnished = command.IsFurnished,
                IsInGatedCommunity = command.IsInGatedCommunity,
                KitchenArea = command.KitchenArea,
                LivingArea = command.LivingArea,
                OwnerCount = command.OwnerCount,
                OwnershipType = EnumExtensions.ConvertToEnum<OwnershipType>(command.OwnershipType),
                OwnershipYears = command.OwnershipYears,
                Price = command.Price,
                PropertyCondition = EnumExtensions.ConvertToEnum<PropertyCondition>(command.PropertyCondition),
                PropertyType = EnumExtensions.ConvertToEnum<PropertyType>(command.PropertyType),
                PropertyUsageType = (PropertyUsageType)EnumExtensions.ConvertToEnum<PropertyUsageType>(command.PropertyUsageType),
                PublisherPhoneNumber = command.PublisherPhoneNumber,
                Renovation = EnumExtensions.ConvertToEnum<Renovation>(command.Renovation),
                RoomCount = command.RoomCount,
                SquareMeters = command.SquareMeters,
                TotalFloors = command.TotalFloors,
                WallMaterial = EnumExtensions.ConvertToEnum<WallMaterial>(command.WallMaterial),
                WindowView = EnumExtensions.ConvertToEnum<WindowViewType>(command.WindowView),
                YearBuilt = command.YearBuilt
            }), cancellationToken);

            return Ok(realEstate.ToResponse());
        }
    }
}
