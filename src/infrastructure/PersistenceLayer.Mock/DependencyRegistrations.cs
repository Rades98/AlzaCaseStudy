using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using PersistanceLayer.Contracts;

namespace PersistenceLayer.Mock
{
	public static class DependencyRegistrations
	{
		public static IServiceCollection RegisterDatabase(this IServiceCollection services)
		{
			services.AddDbContext<ADbContextMock>(options =>
			{
				options.UseInMemoryDatabase(Guid.NewGuid().ToString());
				options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			})
					.AddScoped<IDbContext>(provider => provider.GetRequiredService<ADbContextMock>());
			return services;
		}
	}
}
