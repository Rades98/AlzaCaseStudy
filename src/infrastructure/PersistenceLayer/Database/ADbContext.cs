namespace PersistenceLayer.Database
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Orders;
    using DomainLayer.Entities.Product;
    using DomainLayer.Entities.Users;
    using Extensions;
    using Microsoft.EntityFrameworkCore;

    public class ADbContext : DbContext, IDbContext
    {
        public ADbContext(DbContextOptions<ADbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ADbContext).Assembly)
                .SeedData();
        }

        /// <inheritdoc/>
        public override int SaveChanges()
        {
            ChangeStateInfo();
            return base.SaveChanges();
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeStateInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

        #region Tables

        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
        public DbSet<ProductDetailInfoEntity> ProductDetailInfos => Set<ProductDetailInfoEntity>();
        public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();

        public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<UserRoleRelationEntity> UserRoleRelation => Set<UserRoleRelationEntity>();
        
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<OrderStatusEntity> OrderStatuses => Set<OrderStatusEntity>();

        #endregion

        #region private methods 

        /// <summary>
        /// Manages changes for auditable entities
        /// </summary>
        private void ChangeStateInfo()
        {
            ChangeTracker.Entries<ProductEntity>()
                .ToList()
                .ForEach(entry =>
                {
                    entry.Entity.Created = entry.State == EntityState.Added ? DateTime.Now : entry.Entity.Created;
                    entry.Entity.Changed = entry.State == EntityState.Modified ? DateTime.Now : entry.Entity.Changed;
                    entry.Entity.Deleted = entry.State == EntityState.Deleted ? DateTime.Now : entry.Entity.Deleted;
                });
        }

        #endregion
    }
}
