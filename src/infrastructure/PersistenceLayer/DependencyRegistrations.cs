namespace PersistenceLayer
{
    using ApplicationLayer.Interfaces;
    using Database;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

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
