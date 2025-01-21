using Ijora.Domain.Interactions.Auth.Commands.Auth;
using Ijora.Domain.Interactions.Auth.Commands.Verify;
using Ijora.RestAPI.Api.V1.Mappers;
using Ijora.RestAPI.Api.V1.Models;
using Ijora.RestAPI.Api.V1.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ijora.RestAPI.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    public class AuthController : IjoraApiControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logins([FromBody] AuthRequest authRequest)
        {
            var auth = await Mediator.Send(new AuthCommand(authRequest.Phone));
            return Ok(auth.ToResponse());
        }

        /// <summary>
        /// Подтверждение авторизации с помощью одноразового пароля.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyRequest request)
        {
            var auth = await Mediator.Send(new VerifyOTPCommand(request.Phone, request.OTP));
            return Ok(auth.ToResponse());
        }
    }
}
