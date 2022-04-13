namespace API.Registrations
{
    using Serilog;

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
