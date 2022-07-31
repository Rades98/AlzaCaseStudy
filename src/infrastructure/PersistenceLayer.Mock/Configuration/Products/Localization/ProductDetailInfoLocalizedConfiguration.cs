namespace PersistenceLayer.Mock.Configuration.Products.Localization
{
	using DomainLayer.Entities.Product.Localization;
	using Microsoft.EntityFrameworkCore;

	public static class ProductDetailInfoLocalizedConfiguration
	{
		public static void ConfigureProductDetailInfoLocalizedEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.HasKey(prodDetInf => prodDetInf.Id);

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.Property(prodDetInf => prodDetInf.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.Property(prodDetInf => prodDetInf.ProductDetailInfoId)
				.IsRequired();

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.Property(prodDetInf => prodDetInf.DetailedDescription)
			   .IsRequired();

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.Property(prodDetInf => prodDetInf.Parameters)
			   .IsRequired();

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.Property(prodDetInf => prodDetInf.Created)
				.IsRequired();

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.HasOne(prodDetInfl => prodDetInfl.ProductDetailInfo)
				.WithMany(prodDetInf => prodDetInf.Localizations)
				.HasForeignKey(prodDetInfl => prodDetInfl.ProductDetailInfoId);

			modelBuilder.Entity<ProductDetailInfoLocalizedEntity>()
				.HasOne(prodDetInfl => prodDetInfl.Language)
				.WithMany()
				.HasForeignKey(prodDetInfl => prodDetInfl.LanguageId);
		}
	}
}
