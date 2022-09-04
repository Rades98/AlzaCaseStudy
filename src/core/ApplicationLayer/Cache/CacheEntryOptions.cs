using Microsoft.Extensions.Caching.Memory;
using static ApplicationSetting.ApplicationSetting;

namespace ApplicationLayer.Cache
{
	/// <summary>
	/// Options for cache
	/// </summary>
	public class CacheEntryOptions : MemoryCacheEntryOptions
	{
		public static CacheEntryOptions Default => new()
		{
			AbsoluteExpiration = DateTime.Now.AddMinutes(CACHE_EXPIRATION_TIME_MINS),
			SlidingExpiration = TimeSpan.FromMinutes(CACHE_SLIDING_EXPIRATION_TIME_MINS)
		};
	}
}
