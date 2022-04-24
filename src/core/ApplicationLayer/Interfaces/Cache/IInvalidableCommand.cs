namespace ApplicationLayer.Interfaces.Cache
{
    /// <summary>
    /// Invalidable command (remove/invalidate data from cache on update etc)
    /// </summary>
    public interface IInvalidableCommand
    {
        string CacheKey { get; }
    }
}
