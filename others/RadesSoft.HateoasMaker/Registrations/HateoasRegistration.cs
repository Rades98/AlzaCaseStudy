namespace RadesSoft.HateoasMaker.Registrations
{
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.AspNetCore.Mvc.Routing;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Extensions;
	using RadesSoft.HateoasMaker;

	public static class HateoasRegistration
	{
		public static IServiceCollection RegisterHateoas(this IServiceCollection services)
		{
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.TryAddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
			services.TryAddScoped<IActionContextAccessor, ActionContextAccessor>();
			services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();

			services.AddScoped(sp =>
			{
				var actionContext = sp.GetRequiredService<IActionContextAccessor>().ActionContext;
				var urlHelperFactory = sp.GetRequiredService<IUrlHelperFactory>();
				return urlHelperFactory.GetUrlHelper(actionContext);
			});

			services.AddScoped<HateoasMaker>();

			return services;
		}
	}
}

