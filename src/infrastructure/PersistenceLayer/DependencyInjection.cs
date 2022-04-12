namespace PersistenceLayer
{
    using ApplicationLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Database;

    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ADbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ADb")))
                    .AddScoped<IDbContext>(provider => provider.GetRequiredService<ADbContext>());

            return services;
        }
    }
}
