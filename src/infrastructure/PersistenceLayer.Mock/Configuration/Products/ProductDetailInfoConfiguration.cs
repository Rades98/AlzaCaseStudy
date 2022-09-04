using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Products
{
	internal static class ProductDetailInfoConfiguration
	{
		public static void ConfigureProductDetailInfoEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDetailInfoEntity>()
				.HasKey(pd => pd.Id);

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.Property(pd => pd.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.Property(pd => pd.Created)
				.IsRequired();

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.Property(pd => pd.DetailedDescription)
				.HasMaxLength(5000)
				.IsRequired();

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.Property(pd => pd.Parameters)
				.HasMaxLength(5000)
				.IsRequired();

			modelBuilder.Entity<ProductDetailInfoEntity>()
				.HasOne(p => p.ProductDetail)
				.WithOne(p => p.ProductDetailInfo)
				.HasForeignKey<ProductDetailEntity>(c => c.Id);
		}
	}
}
