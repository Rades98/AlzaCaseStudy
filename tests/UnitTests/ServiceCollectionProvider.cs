namespace UnitTests
{
	using System;
	using System.Text;
	using ApplicationLayer;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;
	using Microsoft.IdentityModel.Tokens;
	using PersistenceLayer;
	using PersistenceLayer.Mock;

	internal class ServiceCollectionProvider
	{
		private readonly ServiceCollection _serviceCollection = new();
		private readonly ServiceProvider _provider;

		public readonly byte[] Token = System.Text.Encoding.UTF8.GetBytes("E9B22F7125BFDC355B2149B2A42C28918E862E69BBAFC32FC174ADE6FF");

		public ServiceCollectionProvider()
		{
			_serviceCollection.RegisterDatabase();
			_serviceCollection.AddApplicationServices();

			_serviceCollection.AddLogging(opt =>
			{
				opt.ClearProviders();
			});

			_serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new()
						{
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E9B22F7125BFDC355B2149B2A42C28918E862E69BBAFC32FC174ADE6FF")),
							ValidateIssuer = false,
							ValidateAudience = false,
						};
					});

			_serviceCollection.RegisterRepositories();
			_serviceCollection.RegisterRepositoryDecorators();

			_provider = _serviceCollection.BuildServiceProvider();
		}

		public T GetService<T>() where T : notnull
		{
			var service = _provider.GetService<T>();

			if (service is not null)
			{
				return service;
			}

			throw new InvalidOperationException($"cannot load {typeof(T)}");
		}
	}
}
