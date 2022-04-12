using PersistenceLayer;

namespace API.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDatabase(configuration);

            return services;
        }
    }
}
