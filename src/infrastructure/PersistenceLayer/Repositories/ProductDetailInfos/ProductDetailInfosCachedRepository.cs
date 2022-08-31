namespace PersistenceLayer.Repositories.ProductDetailInfos
{
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using DomainLayer.Entities.Product;
	using Microsoft.Extensions.Caching.Memory;
	using Newtonsoft.Json;
	using PersistanceLayer.Contracts.Repositories;
	using static ApplicationSetting.ApplicationSetting;

	public class ProductDetailInfosCachedRepository : IProductDetailInfosRepository
	{
		private readonly IMemoryCache _cache;
		private readonly IProductDetailInfosRepository _repo;

		public ProductDetailInfosCachedRepository(IMemoryCache cache, IProductDetailInfosRepository repo)
		{
			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		public async Task<ProductDetailInfoEntity> GetProductDetailInofAsync(string productCode, CancellationToken ct)
		{
			string cacheKey = $"{nameof(ProductDetailInfoEntity)}{productCode}";

			object? cachedResponse = _cache.Get(cacheKey);

			if (cachedResponse != null)
			{
				var res = JsonConvert.DeserializeObject<ProductDetailInfoEntity>(Encoding.Default.GetString((byte[])cachedResponse));
				if (res is not null)
				{
					return res;
				}
			}

			var response = await _repo.GetProductDetailInofAsync(productCode, ct);

			byte[]? serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));

			_cache.Set(cacheKey, serializedData, new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(CACHE_EXPIRATION_TIME_MINS),
				SlidingExpiration = TimeSpan.FromMinutes(CACHE_SLIDING_EXPIRATION_TIME_MINS)
			});

			return response;
		}
	}
}
