namespace PersistenceLayer.Mock.Configuration.Products.Localization
{
	using DomainLayer.Entities.Product.Localization;
	using Microsoft.EntityFrameworkCore;

	public static class ProductCategoryLocalizedConfiguration
	{
		public static void ConfigureProductCategoriesLocalizedEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.HasKey(prodCat => prodCat.Id);

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.Property(prodCat => prodCat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.Property(prodCat => prodCat.ProductCategoryId)
				.IsRequired();

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.Property(prodCat => prodCat.Name)
			   .IsRequired();

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.Property(prodCat => prodCat.Created)
				.IsRequired();

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.HasOne(prodCatl => prodCatl.ProductCategory)
				.WithMany(prodCat => prodCat.Localizations)
				.HasForeignKey(prodCatl => prodCatl.ProductCategoryId);

			modelBuilder.Entity<ProductCategoryLocalizedEntity>()
				.HasOne(prodCatl => prodCatl.Language)
				.WithMany()
				.HasForeignKey(prodCatl => prodCatl.LanguageId);
		}
	}
}
