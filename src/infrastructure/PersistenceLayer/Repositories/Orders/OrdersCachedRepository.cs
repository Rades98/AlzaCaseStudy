namespace PersistenceLayer.Repositories.OrdersRepository
{
	using System.Linq.Expressions;
	using System.Text;
	using DomainLayer.Entities.Orders;
	using Microsoft.Extensions.Caching.Memory;
	using Newtonsoft.Json;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;
	using static ApplicationSetting.ApplicationSetting;

	public class OrdersCachedRepository : IOrdersRepository, ICacheableRepo
	{
		private readonly IMemoryCache _cache;
		private readonly IOrdersRepository _ordersRepository;

		public OrdersCachedRepository(IMemoryCache cache, IOrdersRepository repo)
		{
			_cache = cache ?? throw new ArgumentNullException(nameof(cache));
			_ordersRepository = repo ?? throw new ArgumentNullException(nameof(repo));
		}

		/// <inheritdoc/>
		public Task<string> CreateOrderAsync(int userId, CancellationToken ct)
		{
			string cacheKey = $"{nameof(List<OrderEntity>)}{userId}";
			_cache.Remove(cacheKey);
			return _ordersRepository.CreateOrderAsync(userId, ct);
		}

		/// <inheritdoc/>
		public async Task<List<OrderEntity>> GetOrdersByUserId(int userId, Expression<Func<OrderEntity, bool>> whereFilter, CancellationToken ct)
		{
			string cacheKey = $"{nameof(List<OrderEntity>)}{userId}";

			object? cachedResponse = _cache.Get(cacheKey);

			if (cachedResponse != null)
			{
				var res = JsonConvert.DeserializeObject<List<OrderEntity>>(Encoding.Default.GetString((byte[])cachedResponse));
				if (res is not null)
				{
					return res;
				}
			}

			var response = await _ordersRepository.GetOrdersByUserId(userId, whereFilter, ct);

			byte[] serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
			_cache.Set(cacheKey, serializedData, new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(CACHE_EXPIRATION_TIME_MINS),
				SlidingExpiration = TimeSpan.FromMinutes(CACHE_SLIDING_EXPIRATION_TIME_MINS)
			});

			return response;
		}

		/// <inheritdoc/>
		public async Task OrderChangeStatusAsync(string orderCode, int statusId, int userId, CancellationToken ct)
		{
			await _ordersRepository.OrderChangeStatusAsync(orderCode, statusId, userId, ct);

			string cacheKey = $"{nameof(List<OrderEntity>)}{userId}";
			_cache.Remove(cacheKey);
		}

		/// <inheritdoc/>
		public Task StornoOrderAsync(int userId, string orderCode, CancellationToken ct)
		{
			string cacheKey = $"{nameof(List<OrderEntity>)}{userId}";
			_cache.Remove(cacheKey);

			return _ordersRepository.StornoOrderAsync(userId, orderCode, ct);
		}
	}
}
