namespace ApplicationLayer.Utils
{
    using Interfaces;
    using MediatR;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Text;

    /// <summary>
    /// Generic pipeline to store/load records to/from cache
    /// </summary>
    /// <typeparam name="TRequest">request</typeparam>
    /// <typeparam name="TResponse">response</typeparam>
    public class CachingRecordsPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICacheableWithIdQuery
        where TResponse : IRecord
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<TResponse> _logger;

        public CachingRecordsPipeline(IDistributedCache cache, ILogger<TResponse> logger) => (_cache, _logger) = (cache, logger);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cachedResponse = _cache.Get(request.CacheKey);

            if (cachedResponse != null)
            {
                var fromCache = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(Encoding.Default.GetString(cachedResponse));
                if (fromCache is not null)
                {
                    var result = fromCache.FirstOrDefault(x => x.Id == request.Id);

                    if (result is not null)
                    {
                        _logger.LogInformation($"Fetched from Cache : '{request.CacheKey}'.");
                        return result;
                    }
                }
            }

            //Dont store found object in this case due the fact it should be harder to manage
            //data when there were more complex data

            return await next();
        }
    }
}
