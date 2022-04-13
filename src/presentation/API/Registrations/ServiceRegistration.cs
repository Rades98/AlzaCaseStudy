namespace API.Registrations
{
    using API.Registrations.Swagger;
    using ApplicationLayer;
    using PersistenceLayer;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDatabase(configuration);
            services.AddApplicationServices();
            services.AddCustomApiVersioning();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddMemoryCache();

            return services;
        }
    }
}
