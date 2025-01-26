using Ijora.Domain.Interactions.Auth.Commands.Auth;
using Ijora.Domain.Interactions.Auth.Commands.RefreshToken;
using Ijora.Domain.Interactions.Auth.Commands.Verify;
using Ijora.Domain.Interactions.Auth.Exceptions;
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
        // ToDo обновление токена 
        // ToDo отправка смс 
        // ToDo возврат данных в заголовках при вводе номера телефона
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
        {
            try
            {
                var auth = await Mediator.Send(new AuthCommand(authRequest.Phone));
                Response.Headers.Add("otp", auth.OTP);
                return Ok(true);
            }
            catch (InvalidPhoneNumberException e)
            {
                return BadRequest(new ErrorResponseModel(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseModel(e.Message));
            }
        }

        /// <summary>
        /// Подтверждение авторизации с помощью одноразового пароля.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyRequest request)
        {
            try
            {
                var auth = await Mediator.Send(new VerifyOTPCommand(request.Phone, request.OTP));
                WriteAccessTokens(auth);
                return Ok(auth.User.ToResponse());
            }
            catch (OTPExpieredException e)
            {
                return BadRequest(new ErrorResponseModel(e.Message));
            }
            catch (IncorrectOTPException e)
            {
                return BadRequest(new ErrorResponseModel(e.Message));
            }
            catch (TooManyAttemptsOPTException e)
            {
                return BadRequest(new ErrorResponseModel(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseModel(e.Message + e.InnerException?.Message ?? ""));
            }
        }

        /// <summary>
        /// Обновление токена доступа.
        /// 
        /// Сценария работы:
        /// Клиент делает запрос с токеном доступа.
        /// Если токен действителен — сервер обрабатывает запрос.
        /// Если токен недействителен (истёк или отозван), сервер возвращает 401 Unauthorized.
        /// Клиент, получив 401, отправляет запрос на обновление токена с использованием токена обновления.
        /// Если токен обновления действителен, сервер возвращает новый токен доступа.
        /// Клиент повторяет первоначальный запрос с новым токеном.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var auth = await Mediator.Send(new RefreshTokenCommand(request.RefreshToken));
                WriteAccessTokens(auth);
                return Ok(auth.User.ToResponse());
            }
            catch (AccessModelNotFoundException e)
            {
                return BadRequest(new ErrorResponseModel("Не авторизован"));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseModel(e.Message + e.InnerException?.Message ?? ""));
            }
        }
    }
}
