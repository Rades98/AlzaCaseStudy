using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Products
{
	internal static class ProductConfigurations
	{
		public static void ConfigureProductEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductEntity>()
				.HasKey(product => product.Id);

			modelBuilder.Entity<ProductEntity>()
				.Property(product => product.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductEntity>()
				.Property(product => product.Created)
				.IsRequired();

			modelBuilder.Entity<ProductEntity>()
				.HasOne(product => product.ProductDetail)
				.WithMany(pd => pd.Products)
				.HasForeignKey(product => product.ProductDetailId);
		}
	}
}
