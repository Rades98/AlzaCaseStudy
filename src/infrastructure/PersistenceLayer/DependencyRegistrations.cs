using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Repositories;
using PersistenceLayer.Database;
using PersistenceLayer.Repositories.OrderItems;
using PersistenceLayer.Repositories.OrdersRepository;
using PersistenceLayer.Repositories.ProductCategories;
using PersistenceLayer.Repositories.ProductDetailInfos;
using PersistenceLayer.Repositories.ProductDetails;
using PersistenceLayer.Repositories.Products;
using PersistenceLayer.Repositories.Users;

namespace PersistenceLayer
{
	public static class DependencyRegistrations
	{
		public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ADbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("ADb"));
				options.EnableSensitiveDataLogging();
			})
					.AddScoped<IDbContext>(provider => provider.GetRequiredService<ADbContext>());
			return services;
		}

		public static IServiceCollection RegisterRepositories(this IServiceCollection services)
		{
			services.AddTransient<IOrderItemsRepository, OrderItemsRepository>();
			services.AddTransient<IOrdersRepository, OrdersRepository>();
			services.AddTransient<IProductCategoriesRepository, ProductCategoriesRepository>();
			services.AddTransient<IProductsRepository, ProductsRepository>();
			services.AddTransient<IProductDetailInfosRepository, ProductDetailInfosRepository>();
			services.AddTransient<IProductDetailsRepository, ProductDetailsRepository>();
			services.AddTransient<IUsersRepository, UsersRepository>();

			return services;
		}

		public static IServiceCollection RegisterRepositoryDecorators(this IServiceCollection services)
		{
			services.Decorate<IOrdersRepository, OrdersCachedRepository>();
			services.Decorate<IProductCategoriesRepository, ProductCategoriesCachedRepository>();
			services.Decorate<IProductsRepository, ProductsCachedRepository>();
			services.Decorate<IProductDetailInfosRepository, ProductDetailInfosCachedRepository>();
			services.Decorate<IProductDetailsRepository, ProductDetailsCachedRepository>();

			return services;
		}
	}
}
