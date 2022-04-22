namespace ApplicationLayer.Cache
{
    using Microsoft.Extensions.Caching.Distributed;

    /// <summary>
    /// Options for cache
    /// </summary>
    public class CacheEntryOptions : DistributedCacheEntryOptions
    {
        public static CacheEntryOptions Default => new()
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        };


    }
}
