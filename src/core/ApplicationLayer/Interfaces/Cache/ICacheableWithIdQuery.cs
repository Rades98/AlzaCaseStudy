namespace ApplicationLayer.Interfaces.Cache
{
    /// <summary>
    /// Cacheable query with specific id (load from cache)
    /// </summary>
    public interface ICacheableWithIdQuery
    {
        public Guid Id { get; set; }
        string CacheKey { get; }
    }
}
