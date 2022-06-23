namespace PersistenceLayer.Database.Configuration.Products.Localization
{
	using DomainLayer.Entities.Product.Localization;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ProductCategoryLocalizedConfiguration : IEntityTypeConfiguration<ProductCategoryLocalizedEntity>
	{
		public void Configure(EntityTypeBuilder<ProductCategoryLocalizedEntity> builder)
		{
			builder.ToTable("ProductCategoriesLocalized");
			builder.HasKey(prodCat => prodCat.Id);

			builder.Property(prodCat => prodCat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(prodCat => prodCat.ProductCategoryId)
				.IsRequired();

			builder.Property(prodCat => prodCat.Name)
			   .IsRequired();

			builder.Property(prodCat => prodCat.Created)
				.IsRequired();

			builder.HasOne(prodCatl => prodCatl.ProductCategory)
				.WithMany(prodCat => prodCat.Localizations)
				.HasForeignKey(prodCatl => prodCatl.ProductCategoryId);

			builder.HasOne(prodCatl => prodCatl.Language)
				.WithMany()
				.HasForeignKey(prodCatl => prodCatl.LanguageId);
		}
	}
}
