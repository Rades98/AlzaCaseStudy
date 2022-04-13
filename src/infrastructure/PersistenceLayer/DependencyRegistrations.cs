namespace PersistenceLayer
{
    using ApplicationLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Database;
    using PersistenceLayer.Repositories;

    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ADbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ADb")))
                    .AddScoped<IDbContext>(provider => provider.GetRequiredService<ADbContext>())
                    .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
