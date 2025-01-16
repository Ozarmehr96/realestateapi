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
        public async Task<IActionResult> Create([FromBody] CreateRealEstateRequest command)
        {
            return Ok(5);
            ///var realEstateId = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { id = realEstateId }, null);
        }
    }
}
