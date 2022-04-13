namespace API.Cache
{
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Options for cache
    /// </summary>
    public class CacheEntryOptions : MemoryCacheEntryOptions
    {
        private static readonly Lazy<CacheEntryOptions> _lazy = new(() => new());

        public static CacheEntryOptions Default => _lazy.Value;

        public CacheEntryOptions()
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(5);
            SlidingExpiration = TimeSpan.FromMinutes(2);
        }
    }
}
