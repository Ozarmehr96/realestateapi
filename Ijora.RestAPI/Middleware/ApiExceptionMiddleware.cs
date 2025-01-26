using Ijora.RestAPI.Api.V1.Models;
using Newtonsoft.Json;
using System.Text;

namespace Ijora.RestAPI.Middleware
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public ApiExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IWebHostEnvironment environment)
        {
            _logger = loggerFactory.CreateLogger("Ijora.RestApi.Error");
            _next = next;
            _env = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            using (_logger.BeginScope(context.Request.Path))
            {
                try
                {
                    _logger.LogDebug("Request received");
                    await _next(context);
                    _logger.LogDebug("Request processed");
                }
                //Catching not implemented methods
                catch (NotImplementedException ex) when (_env.IsDevelopment())
                {
                    context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    await SetResponseErrorBody(context, $"Not implemented: {ex.Message}");
                }
                // Catching use-case exceptions
                catch (Domain.Infrastructure.DomainBaseException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await SetResponseErrorBody(context, $"Unhandled use-case exception: {ex.Message}");
                }
                // Catching cadas exceptions
                catch (System.Data.SqlClient.SqlException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await SetResponseErrorBody(context, $"Database-Error: {ex.Message}");
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await SetResponseErrorBody(context, $"Database-Error: {ex.Message} {ex.InnerException}");
                }
                // Catching unhandled critical errors
                catch (Exception ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    _logger.LogCritical(ex.ToString());
                    await SetResponseErrorBody(context, $"Critical-Error: {ex.Message}");
                }
            }
        }

        private async Task SetResponseErrorBody(HttpContext context, string error)
        {
            _logger.LogError(error);
            string jsonErrorResponse = JsonConvert.SerializeObject(new ErrorResponseModel(error));

            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonErrorResponse);

                // Записываем байтовый массив в поток
                await context.Response.Body.WriteAsync(byteArray, 0, byteArray.Length);

                // Если необходимо, можно вызвать FlushAsync для явной очистки
                await context.Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing response");
            }
        }
    }
}

