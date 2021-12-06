using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAuth.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private Random rnd = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTime = rnd.Next(1, 1000);

            if (responseTime < 400)
            {
                return Task.FromResult(HealthCheckResult.Healthy("DB is fine"));
            }
            else if (responseTime < 800)
            {
                return Task.FromResult(HealthCheckResult.Degraded("DB is slow"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("DB is unhealthy"));
            }
        }
    }
}
