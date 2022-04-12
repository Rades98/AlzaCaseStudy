using Serilog;

namespace API.Registrations
{
    public static class LoggingRegistration
    {
        public static IHostBuilder AddLogger(this IHostBuilder builder)
        {
            builder.UseSerilog((hostingContext, loggerConfig) =>
               loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
            );

            return builder;
        }
    }
}
