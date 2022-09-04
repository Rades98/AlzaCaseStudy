using System.Text;
using DomainLayer.Entities.Product;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PersistanceLayer.Contracts.Repositories;
using static ApplicationSetting.ApplicationSetting;

namespace PersistenceLayer.Repositories.ProductDetails
{
	public class ProductDetailsCachedRepository : IProductDetailsRepository
	{
		private readonly IMemoryCache _cache;
		private readonly IProductDetailsRepository _repo;

		public ProductDetailsCachedRepository(IMemoryCache cache, IProductDetailsRepository repo)
		{
			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
			_repo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		public async Task<ProductDetailEntity> GetProductDetailByProductCode(string productCode, CancellationToken ct)
		{
			var cacheKey = $"{nameof(ProductDetailEntity)}{productCode}";

			var cachedResponse = _cache.Get(cacheKey);

			if (cachedResponse != null)
			{
				var res = JsonConvert.DeserializeObject<ProductDetailEntity>(Encoding.Default.GetString((byte[])cachedResponse));
				if (res is not null)
				{
					return res;
				}
			}

			var response = await _repo.GetProductDetailByProductCode(productCode, ct);

			var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
			_cache.Set(cacheKey, serializedData, new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(CACHE_EXPIRATION_TIME_MINS),
				SlidingExpiration = TimeSpan.FromMinutes(CACHE_SLIDING_EXPIRATION_TIME_MINS)
			});

			return response;
		}

		public Task<List<ProductDetailEntity>> GetProductDetailsAsync(Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct)
			=> _repo.GetProductDetailsAsync(orderBy, orderByDesc, ct);

		public Task<List<ProductDetailEntity>> GetProductDetailsPaginatedAsync(int pageNumber, int pageSize, Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct)
			=> _repo.GetProductDetailsPaginatedAsync(pageNumber, pageSize, orderBy, orderByDesc, ct);

		public async Task<ProductDetailEntity> UpdateProductDetailDescriptionAsync(int productId, string newDescription, CancellationToken ct)
		{
			var entity = await _repo.UpdateProductDetailDescriptionAsync(productId, newDescription, ct);
			string cacheKey = $"{nameof(ProductDetailEntity)}{entity.ProductCode}";

			_cache.Remove(cacheKey);

			return entity;
		}
	}
}
