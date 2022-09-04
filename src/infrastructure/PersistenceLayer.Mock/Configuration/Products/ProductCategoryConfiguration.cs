using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Products
{
	internal static class ProductCategoryConfiguration
	{
		public static void ConfigureProductCategoryEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductCategoryEntity>()
				.HasKey(productCategory => productCategory.Id);

			modelBuilder.Entity<ProductCategoryEntity>()
				.Property(productCategory => productCategory.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductCategoryEntity>()
				.Property(productCategory => productCategory.Created)
				.IsRequired();

			modelBuilder.Entity<ProductCategoryEntity>()
				.Property(productCategory => productCategory.Name)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<ProductCategoryEntity>()
				.Property(productCategory => productCategory.Description)
				.HasMaxLength(250);

			modelBuilder.Entity<ProductCategoryEntity>()
				.HasOne(pc => pc.ParentProductCategory)
				.WithMany(pc => pc.ChildrenCategories)
				.HasForeignKey(pc => pc.ParentProductCategoryId);
		}
	}
}
