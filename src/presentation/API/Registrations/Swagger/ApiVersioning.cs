using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Registrations.Swagger
{
	public static class ApiVersioning
	{
		public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(o =>
			{
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
				o.ReportApiVersions = true;
				o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
			});

			services.AddVersionedApiExplorer(o =>
			{
				o.GroupNameFormat = "'v'VVV";
				o.SubstituteApiVersionInUrl = true;
			});

			return services;
		}
	}
}
