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

        [HttpGet("id")]
        public async Task<IActionResult> Get()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRealEstateRequest command)
        {
            var realEstateId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = realEstateId }, null);
        }
    }
}
