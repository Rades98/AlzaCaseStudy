namespace PersistenceLayer.Database.Configuration.Products.Localization
{
	using DomainLayer.Entities.Product.Localization;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class ProductDetailLocalizedConfiguration : IEntityTypeConfiguration<ProductDetailLocalizedEntity>
	{
		public void Configure(EntityTypeBuilder<ProductDetailLocalizedEntity> builder)
		{
			builder.ToTable("ProductDetailsLocalized");
			builder.HasKey(prodCat => prodCat.Id);

			builder.Property(prodCat => prodCat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(prodCat => prodCat.ProductDetailId)
				.IsRequired();

			builder.Property(prodCat => prodCat.Name)
			   .IsRequired();

			builder.Property(prodCat => prodCat.ImgUri)
			   .IsRequired();

			builder.Property(prodCat => prodCat.Created)
				.IsRequired();

			builder.HasOne(prodCatl => prodCatl.ProductDetail)
				.WithMany(prodCat => prodCat.Localizations)
				.HasForeignKey(prodCatl => prodCatl.ProductDetailId);

			builder.HasOne(prodCatl => prodCatl.Language)
				.WithMany()
				.HasForeignKey(prodCatl => prodCatl.LanguageId);
		}
	}
}
