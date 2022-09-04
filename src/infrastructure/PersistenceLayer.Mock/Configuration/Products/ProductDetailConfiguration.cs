using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Products
{
	internal static class ProductDetailConfiguration
	{
		public static void ConfigureProductDetailEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDetailEntity>()
				.HasKey(pd => pd.Id);

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.Created)
				.IsRequired();

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.Name)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.Price)
				.HasPrecision(12, 2)
				.IsRequired();

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.ImgUri)
				.IsRequired()
				.HasConversion(uriIn => uriIn.ToString(), utiOut => new Uri(utiOut));

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.Description)
				.HasMaxLength(250);

			modelBuilder.Entity<ProductDetailEntity>()
				.Property(pd => pd.ProductCode)
				.HasMaxLength(8)
				.IsRequired();

			modelBuilder.Entity<ProductDetailEntity>()
				.HasOne(x => x.ProductCategory)
				.WithMany(x => x.ProductDetails)
				.HasForeignKey(x => x.ProductCategoryId);

			modelBuilder.Entity<ProductDetailEntity>()
				.HasIndex(p => p.ProductCode)
				.IsUnique();

			modelBuilder.Entity<ProductDetailEntity>()
				.HasOne(p => p.ProductDetailInfo)
				.WithOne(p => p.ProductDetail)
				.HasForeignKey<ProductDetailInfoEntity>(c => c.ProductDetailId);
		}
	}
}
