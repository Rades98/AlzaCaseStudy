namespace API.Registrations
{
    using API.Registrations.HealthChecks;
    using ApplicationLayer;
    using PersistenceLayer;
    using Swagger;
    using System.Reflection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.RegisterDatabase(configuration);
            services.AddApplicationServices();
            services.AddCustomApiVersioning();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddSwaggerGen(o =>
            {
                o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
            services.AddCustomHealthChecks(configuration);

            return services;
        }
    }
}
