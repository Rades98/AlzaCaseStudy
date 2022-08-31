namespace PersistanceLayer.Contracts
{
	using DomainLayer.Entities.LanguageMutations;
	using DomainLayer.Entities.Orders;
	using DomainLayer.Entities.Orders.Localization;
	using DomainLayer.Entities.Product;
	using DomainLayer.Entities.Product.Localization;
	using DomainLayer.Entities.Users;
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

		public DbSet<LanguageEntity> Languages { get; }
		public DbSet<MessageEntity> Messages { get; }
		public DbSet<MessageTypeEntity> MessageTypes { get; }

		public DbSet<ProductEntity> Products { get; }
		public DbSet<ProductDetailEntity> ProductDetails { get; }
		public DbSet<ProductDetailLocalizedEntity> ProductDetailsLocalized { get; }
		public DbSet<ProductDetailInfoEntity> ProductDetailInfos { get; }
		public DbSet<ProductDetailInfoLocalizedEntity> ProductDetailInfosLocalized { get; }
		public DbSet<ProductCategoryEntity> ProductCategories { get; }
		public DbSet<ProductCategoryLocalizedEntity> ProductCategoriesLocalized { get; }

		public DbSet<UserRegistrationEntity> UserRegistrations { get; }
		public DbSet<UserRoleEntity> UserRoles { get; }
		public DbSet<UserEntity> Users { get; }
		public DbSet<UserRoleRelationEntity> UserRoleRelation { get; }

		public DbSet<OrderEntity> Orders { get; }
		public DbSet<OrderItemEntity> OrderItems { get; }
		public DbSet<OrderStatusEntity> OrderStatuses { get; }
		public DbSet<OrderStatusLocalizedEntity> OrderStatusesLocalized { get; }

		#endregion
	}
}
