using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using PruebaTecnicaKaprielian.Dtos;
using System.Text.Json.Serialization;

namespace PruebaTecnicaKaprielian.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestMiddleware> _logger;

        public RequestMiddleware(RequestDelegate next, ILogger<RequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var request = context.Request;

                var logData = new
                {
                    request.Method,
                    Url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}",
                };

                logData = new
                {
                    logData.Method,
                    logData.Url
                };
                _logger.LogInformation($"Logeo de Informacion {JsonConvert.SerializeObject(logData)}");
                await _next(context);
                _logger.LogInformation("Saliendo de la request");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Se produjo un error interno en el servidor");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                ErrorResponse error = new()
                {
                    Status = 400,
                    Title = "Se produjo un error interno en el servidor",
                    Description = e.Message,
                    TraceId = Guid.NewGuid().ToString()
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
