namespace PersistenceLayer.Mock
{
	using ApplicationLayer.Interfaces;
	using DomainLayer.Entities.LanguageMutations;
	using DomainLayer.Entities.Orders;
	using DomainLayer.Entities.Orders.Localization;
	using DomainLayer.Entities.Product;
	using DomainLayer.Entities.Product.Localization;
	using DomainLayer.Entities.Texts;
	using DomainLayer.Entities.Users;
	using Microsoft.EntityFrameworkCore;
	using PersistenceLayer.Mock.Configuration.LanguageMutations;
	using PersistenceLayer.Mock.Configuration.Orders;
	using PersistenceLayer.Mock.Configuration.Orders.Localization;
	using PersistenceLayer.Mock.Configuration.Products;
	using PersistenceLayer.Mock.Configuration.Products.Localization;
	using PersistenceLayer.Mock.Configuration.Users;

	public class ADbContextMock : DbContext, IDbContext
	{
		public ADbContextMock(DbContextOptions<ADbContextMock> options) : base(options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ConfigureLanguageEntity();
			modelBuilder.ConfigureMessageEntity();
			modelBuilder.ConfigureMessageTypeEntity();

			modelBuilder.ConfigureOrderStatusLocalizedEntity();
			modelBuilder.ConfigureOrderEntity();
			modelBuilder.ConfigureOrderItemEntity();
			modelBuilder.ConfigureOrderStatusEntity();

			modelBuilder.ConfigureProductCategoriesLocalizedEntity();
			modelBuilder.ConfigureProductDetailInfoLocalizedEntity();
			modelBuilder.ConfigureProductDetailLocalizedEntity();
			modelBuilder.ConfigureProductCategoryEntity();
			modelBuilder.ConfigureProductEntity();
			modelBuilder.ConfigureProductDetailEntity();
			modelBuilder.ConfigureProductDetailInfoEntity();

			modelBuilder.ConfigureUserEntity();
			modelBuilder.ConfigureUserRoleEntity();

			modelBuilder.Seed();
		}

		#endregion
	}
}
