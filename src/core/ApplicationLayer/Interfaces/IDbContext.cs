namespace ApplicationLayer.Interfaces
{
    using DomainLayer.Entities.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public interface IDbContext
    {
        public DatabaseFacade Database { get; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #region Tables

        public DbSet<ProductEntity> Products { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        #endregion
    }
}
