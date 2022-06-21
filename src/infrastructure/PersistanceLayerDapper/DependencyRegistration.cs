using Microsoft.Extensions.DependencyInjection;

namespace PersistanceLayerDapper
{
	public static class DependencyRegistration
	{
		public static IServiceCollection RegisterDapper(this IServiceCollection services)
		{
			services.AddSingleton<DapperContext>();
			return services;
		}
	}
}
