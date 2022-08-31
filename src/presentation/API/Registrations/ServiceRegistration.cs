namespace API.Registrations
{
	using System.Reflection;
	using System.Text;
	using ApplicationLayer;
	using HealthChecks;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.IdentityModel.Tokens;
	using Microsoft.OpenApi.Models;
	using PersistanceLayerDapper;
	using PersistenceLayer;
	using RadesSoft.HateoasMaker.Registrations;
	using ResponseCompression;
	using Swagger;
	using Swashbuckle.AspNetCore.Filters;

	public static class ServiceRegistration
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new()
						{
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
							ValidateIssuer = false,
							ValidateAudience = false,						
						};
					});
			services.ConfigureResponseCompression();
			services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
			services.RegisterDatabase(configuration);
			services.RegisterRepositories();
			services.RegisterRepositoryDecorators();
			services.RegisterDapper();
			services.AddApplicationServices();
			services.AddCustomApiVersioning();
			services.ConfigureOptions<ConfigureSwaggerOptions>();
			services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
				{
					Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token} \")",
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				options.OperationFilter<SecurityRequirementsOperationFilter>();

				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
			});
			services.AddCustomHealthChecks(configuration);

			services.RegisterHateoas();

			return services;
		}
	}
}
