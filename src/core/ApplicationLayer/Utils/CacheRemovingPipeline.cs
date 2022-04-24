namespace ApplicationLayer.Utils
{
    using ApplicationLayer.Interfaces.Cache;
    using Interfaces;
    using MediatR;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Generic pipeline to remove data from cache
    /// </summary>
    /// <typeparam name="TRequest">request</typeparam>
    /// <typeparam name="TResponse">response</typeparam>
    public class CacheRemovingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, IInvalidableCommand
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<TResponse> _logger;

        public CacheRemovingPipeline(IDistributedCache cache, ILogger<TResponse> logger) => (_cache, _logger) = (cache, logger);


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _cache.RemoveAsync(request.CacheKey, cancellationToken);
            _logger.LogInformation($"Removed from Cache : '{request.CacheKey}'.");
            return await next();
        }
    }
}
