namespace PersistenceLayer.Database
{
	using ApplicationLayer.Interfaces;
	using DomainLayer.Entities.LanguageMutations;
	using DomainLayer.Entities.Orders;
	using DomainLayer.Entities.Orders.Localization;
	using DomainLayer.Entities.Product;
	using DomainLayer.Entities.Product.Localization;
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

        public DbSet<LanguageEntity> Languages => Set<LanguageEntity>();

        public DbSet<MessageEntity> Messages => Set<MessageEntity>();
        public DbSet<MessageTypeEntity> MessageTypes => Set<MessageTypeEntity>();

        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
        public DbSet<ProductDetailLocalizedEntity> ProductDetailsLocalized => Set<ProductDetailLocalizedEntity>();
        public DbSet<ProductDetailInfoEntity> ProductDetailInfos => Set<ProductDetailInfoEntity>();
        public DbSet<ProductDetailInfoLocalizedEntity> ProductDetailInfosLocalized => Set<ProductDetailInfoLocalizedEntity>();
        public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
        public DbSet<ProductCategoryLocalizedEntity> ProductCategoriesLocalized => Set<ProductCategoryLocalizedEntity>();

        public DbSet<UserRegistrationEntity> UserRegistrations => Set<UserRegistrationEntity>();
        public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<UserRoleRelationEntity> UserRoleRelation => Set<UserRoleRelationEntity>();
        
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<OrderStatusEntity> OrderStatuses => Set<OrderStatusEntity>();
        public DbSet<OrderStatusLocalizedEntity> OrderStatusesLocalized => Set<OrderStatusLocalizedEntity>();

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
