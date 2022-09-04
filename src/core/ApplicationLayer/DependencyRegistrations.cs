namespace ApplicationLayer
{
	using System.Reflection;
	using ApplicationLayer.Pipelines;
	using FluentValidation;
	using MediatR;
	using Microsoft.Extensions.DependencyInjection;
	using Utils.Pipelines;

	public static class DependencyRegistrations
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddMemoryCache();
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingPipeline<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingCollectionsPipeline<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingRecordsPipeline<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingPipeline<,>));

			return services;
		}
	}
}
