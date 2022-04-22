﻿namespace ApplicationLayer.Interfaces
{
    /// <summary>
    /// Cacheable query (cache on get and load from cache)
    /// </summary>
    public interface ICacheableQuery
    {
        string CacheKey { get; }
    }
}
