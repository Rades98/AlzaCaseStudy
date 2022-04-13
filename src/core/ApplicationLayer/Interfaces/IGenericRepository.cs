using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    /// <summary>
    /// Generic repository for managing base db requests
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : AuditableEntity
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Entity or null if there is no found</returns>
        public Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="orderByDesc">Flag for ordering if true then desc else asc</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>List of entities</returns>
        public Task<IReadOnlyList<T>> GetAllAsync(bool orderByDesc, Func<T, object> orderBy, CancellationToken cancellationToken);

        /// <summary>
        /// Get all entities in page of specified size
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="orderByDesc">Flag for ordering if true then desc else asc</param>
        /// <param name="orderBy">order by clause</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Paged List of entities</returns>
        public Task<IReadOnlyList<T>> GetAllPaginatedAsync(int pageNum, int pageSize, bool orderByDesc, Func<T, object> orderBy, CancellationToken cancellationToken);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="cancellationToken">cancellation token</param>
        public Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
