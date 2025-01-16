using Ijora.RestAPI.Api.V1.Models;
using Newtonsoft.Json;
using System.Text;
//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
                    SetResponseErrorBody(context, $"Not implemented: {ex.Message}");
                }
                // Catching use-case exceptions
                catch (Domain.Infrastructure.DomainBaseException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    SetResponseErrorBody(context, $"Unhandled use-case exception: {ex.Message}");
                }
                // Catching cadas exceptions
                catch (System.Data.SqlClient.SqlException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    SetResponseErrorBody(context, $"Database-Error: {ex.Message}");
                }
                // Catching unhandled critical errors
                catch (Exception ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    _logger.LogCritical(ex.ToString());
                    SetResponseErrorBody(context, $"Critical-Error: {ex.Message}");
                }
            }
        }

        private void SetResponseErrorBody(HttpContext context, string error)
        {
            _logger.LogError(error);
            string jsonErrorResponse = JsonConvert.SerializeObject(new ErrorResponseModel(error));
            using (StreamWriter writer = new StreamWriter(context.Response.Body, Encoding.UTF8))
            {
                writer.Write(jsonErrorResponse);
                writer.Flush();
            }
        }
    }
}

