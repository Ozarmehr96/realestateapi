using Ijora.Domain.Interactions.Properties.Queries.GetProperty;
using Ijora.RestAPI.Api.V1.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ijora.RestAPI.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/jobs")]
    [Produces("application/json")]
    public class PropertiesController : IjoraApiControllerBase
    {
        public PropertiesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //var ff = await Mediator.Send(new GetPropertyQuery(7));
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
