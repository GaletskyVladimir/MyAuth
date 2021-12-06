using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAuth.HealthChecks
{
    public class Service2HealthCheck : IHealthCheck
    {
        private Random rnd = new Random();

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTime = rnd.Next(1, 1000);

            if (responseTime < 400)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Service 2 is fine"));
            }
            else if (responseTime < 800)
            {
                return Task.FromResult(HealthCheckResult.Degraded("Service2 is slow"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Service 2 is unhealthy"));
            }
        }
    }
}
