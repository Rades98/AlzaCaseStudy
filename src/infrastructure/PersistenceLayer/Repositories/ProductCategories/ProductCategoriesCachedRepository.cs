using System.Text;
using DomainLayer.Entities.Product;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PersistanceLayer.Contracts.Repositories;
using static ApplicationSetting.ApplicationSetting;

namespace PersistenceLayer.Repositories.ProductCategories
{
	public class ProductCategoriesCachedRepository : IProductCategoriesRepository
	{
		private readonly IMemoryCache _cache;
		private readonly IProductCategoriesRepository _productCategoryRepo;

		public ProductCategoriesCachedRepository(IMemoryCache cache, IProductCategoriesRepository repo)
		{
			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
			_productCategoryRepo = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		/// <inheritdoc/>
		public async Task<List<ProductCategoryEntity>> GetProductCategoriesByIdAsync(int id, CancellationToken ct)
		{
			string cacheKey = $"{nameof(List<ProductCategoryEntity>)}{id}";

			object? cachedResponse = _cache.Get(cacheKey);

			if (cachedResponse != null)
			{
				var res = JsonConvert.DeserializeObject<List<ProductCategoryEntity>>(Encoding.Default.GetString((byte[])cachedResponse));
				if (res is not null)
				{
					return res;
				}
			}

			var response = await _productCategoryRepo.GetProductCategoriesByIdAsync(id, ct);

			byte[]? serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
			_cache.Set(cacheKey, serializedData, new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(5),
				SlidingExpiration = TimeSpan.FromMinutes(2)
			});

			return response;
		}
	}
}
