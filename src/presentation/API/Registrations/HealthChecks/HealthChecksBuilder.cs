﻿namespace API.Registrations.HealthChecks
{
    using API.HealthChecks;

    public static class HealthChecksBuilder
    {
        public static IHealthChecksBuilder AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddHealthChecks();

            builder.AddCheck<HealthCheckDbContextCheck>(nameof(HealthCheckDbContextCheck));

            services.AddHealthChecksUI()
                    .AddSqlServerStorage(configuration.GetConnectionString("HealthChecksDb"));

            return builder;
        }
    }
}
