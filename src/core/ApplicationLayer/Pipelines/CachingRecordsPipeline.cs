namespace ApplicationLayer.Utils.Pipelines
{
	using System.Text;
	using Interfaces;
	using Interfaces.Cache;
	using MediatR;
	using Microsoft.Extensions.Caching.Memory;
	using Microsoft.Extensions.Logging;
	using Newtonsoft.Json;

	/// <summary>
	/// Generic pipeline to store/load records to/from cache
	/// </summary>
	/// <typeparam name="TRequest">request</typeparam>
	/// <typeparam name="TResponse">response</typeparam>
	public class CachingRecordsPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>, ICacheableWithIdQuery
		where TResponse : IRecord
	{
		private readonly IMemoryCache _cache;
		private readonly ILogger<TResponse> _logger;

		public CachingRecordsPipeline(IMemoryCache cache, ILogger<TResponse> logger) => (_cache, _logger) = (cache, logger);

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			object? cachedResponse = _cache.Get(request.CacheKey);

			if (cachedResponse != null)
			{
				var fromCache = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(Encoding.Default.GetString((byte[])cachedResponse));
				if (fromCache is not null)
				{
					var result = fromCache.FirstOrDefault(x => x.Id == request.Id);

					if (result is not null)
					{
						_logger.LogInformation("Fetched from Cache : '{cacheKey}'.", request.CacheKey);
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
