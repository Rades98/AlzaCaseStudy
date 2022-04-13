namespace API.Cache
{
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Options for cache
    /// </summary>
    public class CacheEntryOptions : MemoryCacheEntryOptions
    {
        public static CacheEntryOptions Default => new()
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        };


    }
}
