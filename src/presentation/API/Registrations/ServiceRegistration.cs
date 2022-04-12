namespace API.Registrations
{
    using ApplicationLayer;
    using MediatR;
    using PersistenceLayer;
    using System.Reflection;

    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.RegisterDatabase(configuration);
            services.AddApplicationServices();

            return services;
        }
    }
}
