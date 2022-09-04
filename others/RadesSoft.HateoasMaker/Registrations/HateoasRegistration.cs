using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RadesSoft.HateoasMaker.Registrations
{
	public static class HateoasRegistration
	{
		public static IServiceCollection RegisterHateoas(this IServiceCollection services)
		{
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.TryAddTransient(s =>
			{
				var contextAccessor = s.GetService<IHttpContextAccessor>()?.HttpContext?.User;

				if (contextAccessor is null)
				{
					throw new InvalidOperationException("cannot load IHttpContextAccessor");
				}

				return contextAccessor;
			});
			services.TryAddScoped<IActionContextAccessor, ActionContextAccessor>();
			services.TryAddSingleton<IUrlHelperFactory, UrlHelperFactory>();

			services.AddScoped(sp =>
			{
				var acc = sp.GetRequiredService<IActionContextAccessor>();
				var actionContext = acc.ActionContext;
				var urlHelperFactory = sp.GetRequiredService<IUrlHelperFactory>();

				if (actionContext is null)
				{
					throw new InvalidOperationException("cannot load ActionContext");
				}

				if (urlHelperFactory is null)
				{
					throw new InvalidOperationException("cannot load UrlHelperFactory");
				}

				return urlHelperFactory.GetUrlHelper(actionContext);
			});

			services.AddScoped<HateoasMaker>();

			return services;
		}
	}
}

