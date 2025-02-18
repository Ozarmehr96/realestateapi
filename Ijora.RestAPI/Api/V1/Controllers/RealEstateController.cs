using Ijora.Domain.Interactions.Auth.Exceptions;
using Ijora.Domain.Interactions.Auth.Models;
using Ijora.Domain.Interactions.RealEstates.Commands.Create;
using Ijora.Domain.Interactions.RealEstates.Models;
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
            return Ok(5);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRealEstateRequest command, CancellationToken cancellationToken)
        {

            AuthAccessModel auth;
            try
            {
                auth = await GetAuthorizedAccess(authorizaionHeader, cancellationToken);
            }
            catch (AccessModelNotFoundException)
            {
                return Unauthorized(ErrorText.UNAUTHORIZED.AsResponseModel());
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
                HeatingType = command.HeatingType,
                HasParking = command.HasParking,
                Id = command.Id,
               //ImageUrls = command.ImageUrls,
               IsAvaliable = command.IsAvaliable,
               ImageUrls = command.ImageUrls,
               IsFurnished = command.IsFurnished,
               IsInGatedCommunity = command.IsInGatedCommunity,
               KitchenArea = command.KitchenArea,
               LivingArea = command.LivingArea,
               OwnerCount = command.OwnerCount,
               OwnershipType = command.OwnershipType,
               OwnershipYears = command.OwnershipYears,
               Price = command.Price,
               PropertyCondition = command.PropertyCondition,
               PropertyType = command.PropertyType,
               PropertyUsageType = command.PropertyUsageType,
               PublicationDate = command.PublicationDate,
               PublisherPhoneNumber = command.PublisherPhoneNumber,
               Renovation = command.Renovation,
               RoomCount = command.RoomCount,
               SquareMeters = command.SquareMeters, 
               TotalFloors = command.TotalFloors,
               UserId = command.UserId,
               WallMaterial = command.WallMaterial,
               WindowView  = command.WindowView,
               YearBuilt = command.YearBuilt
            }), cancellationToken);
            return Ok(5);
            ///var realEstateId = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { id = realEstateId }, null);
        }
    }
}
