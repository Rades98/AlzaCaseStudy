namespace ApplicationLayer
{
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using Utils;

    public static class DependencyRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDistributedMemoryCache();
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
