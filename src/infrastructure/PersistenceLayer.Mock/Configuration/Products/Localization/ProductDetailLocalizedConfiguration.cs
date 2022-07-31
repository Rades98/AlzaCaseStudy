namespace PersistenceLayer.Mock.Configuration.Products.Localization
{
	using DomainLayer.Entities.Product.Localization;
	using Microsoft.EntityFrameworkCore;

	internal static class ProductDetailLocalizedConfiguration
	{
		public static void ConfigureProductDetailLocalizedEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.HasKey(prodCat => prodCat.Id);

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.Property(prodCat => prodCat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.Property(prodCat => prodCat.ProductDetailId)
				.IsRequired();

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.Property(prodCat => prodCat.Name)
			   .IsRequired();

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.Property(prodCat => prodCat.ImgUri)
			   .IsRequired();

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.Property(prodCat => prodCat.Created)
				.IsRequired();

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.HasOne(prodCatl => prodCatl.ProductDetail)
				.WithMany(prodCat => prodCat.Localizations)
				.HasForeignKey(prodCatl => prodCatl.ProductDetailId);

			modelBuilder.Entity<ProductDetailLocalizedEntity>()
				.HasOne(prodCatl => prodCatl.Language)
				.WithMany()
				.HasForeignKey(prodCatl => prodCatl.LanguageId);
		}
	}
}
