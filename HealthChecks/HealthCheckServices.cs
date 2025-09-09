using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PruebaTecnicaKaprielian.HealthChecks
{
    public class HealthCheckServices : IHealthCheck
    { 
        public Task<HealthCheckResult> CheckHealthAsync(
     HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy());
            }

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus));
        }
    }
}
