namespace ApplicationLayer.Utils
{
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Generic pipeline to remove data from cache
    /// </summary>
    /// <typeparam name="TRequest">request</typeparam>
    /// <typeparam name="TResponse">response</typeparam>
    public class CacheRemovingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, IInvalidableCommand
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<TResponse> _logger;

        public CacheRemovingPipeline(IMemoryCache cache, ILogger<TResponse> logger) => (_cache, _logger) = (cache, logger);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _cache.Remove(request.CacheKey);
            _logger.LogInformation($"Removed from Cache : '{request.CacheKey}'.");
            return await next();
        }
    }
}
