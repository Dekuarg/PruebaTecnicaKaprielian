using PruebaTecnicaKaprielian.Dtos;

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
                _logger.LogInformation("Se ingresa data");
                await _next(context);
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
