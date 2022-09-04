using System.Text;
using DomainLayer.Entities.Product;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PersistanceLayer.Contracts.Repositories;
using static ApplicationSetting.ApplicationSetting;

namespace PersistenceLayer.Repositories.Products
{
	internal class ProductsCachedRepository : IProductsRepository
	{
		private readonly IMemoryCache _cache;
		private readonly IProductsRepository _repo;

		public ProductsCachedRepository(IMemoryCache cache, IProductsRepository repo)
		{
			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		public async Task<int> GetProductCountByCodeAsync(string productCode, CancellationToken ct)
		{
			var cacheKey = $"{nameof(ProductEntity)}Count{productCode}";

			var cachedResponse = _cache.Get(cacheKey);

			if (cachedResponse != null)
			{
				var res = JsonConvert.DeserializeObject<int?>(Encoding.Default.GetString((byte[])cachedResponse));
				if (res is not null)
				{
					return res.Value;
				}
			}

			var response = await _repo.GetProductCountByCodeAsync(productCode, ct);

			var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
			_cache.Set(cacheKey, serializedData, new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(CACHE_EXPIRATION_TIME_MINS),
				SlidingExpiration = TimeSpan.FromMinutes(CACHE_SLIDING_EXPIRATION_TIME_MINS)
			});

			return response;
		}
	}
}
