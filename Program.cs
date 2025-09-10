using Microsoft.Extensions.Diagnostics.HealthChecks;
using NLog;
using NLog.Web;
using PruebaTecnicaKaprielian.Extensions;
using PruebaTecnicaKaprielian.HealthChecks;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
    builder.Services.AddNhibernate("Server=localhost;Port=3306; Database=pruebatecnica; Uid=root; Pwd=root; SslMode=required;persistsecurityinfo=True");
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHealthChecks()
    .AddCheck<HealthCheckServices>("HealthCheck", HealthStatus.Unhealthy);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", ""));

    app.UseMiddleware<PruebaTecnicaKaprielian.Middleware.RequestMiddleware>();
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseAuthorization();
    app.MapHealthChecks("/Health/Index");
    app.MapControllers();

    app.Run();
}
catch (Exception)
{

	throw;
}
finally
{
    LogManager.Shutdown();
}

