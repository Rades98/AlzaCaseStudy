namespace ApplicationLayer.Interfaces
{
    using DomainLayer.Entities.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    /// <summary>
    /// App db context
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Facade for providing configured database
        /// </summary>
        public DatabaseFacade Database { get; }

        /// <summary>
        /// Save changes inherited from EF core
        /// </summary>
        /// <returns>int status</returns>
        public int SaveChanges();

        /// <summary>
        /// Save changes async inherited from EF core
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>int status</returns>

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #region Tables

        /// <summary>
        /// Generic DB set
        /// </summary>
        /// <typeparam name="TEntity">Entity name</typeparam>
        /// <returns>DBset of specified entity</returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        #endregion
    }
}
