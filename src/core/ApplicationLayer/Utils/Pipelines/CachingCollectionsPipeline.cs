namespace ApplicationLayer.Utils.Pipelines
{
    using Cache;
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Text;

    /// <summary>
    /// Generic pipeline to store/load collections to/from cache
    /// </summary>
    /// <typeparam name="TRequest">request</typeparam>
    /// <typeparam name="TResponse">response</typeparam>
    public class CachingCollectionsPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheableQuery
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<TResponse> _logger;

        public CachingCollectionsPipeline(IMemoryCache cache, ILogger<TResponse> logger) => (_cache, _logger) = (cache, logger);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cachedResponse = _cache.Get(request.CacheKey);

            if (cachedResponse != null)
            {
                TResponse? res = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString((byte[])cachedResponse));
                if (res is not null)
                {
                    _logger.LogInformation($"Fetched from Cache : '{request.CacheKey}'.");
                    return res;
                }
            }

            TResponse response = await next();

            var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
            _cache.Set(request.CacheKey, serializedData, CacheEntryOptions.Default);
            _logger.LogInformation($"Added to Cache : '{request.CacheKey}'.");

            return response;
        }
    }
}
