using DomainLayer.Entities.Product.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Products.Localization
{
	public class ProductDetailInfoLocalizedConfiguration : IEntityTypeConfiguration<ProductDetailInfoLocalizedEntity>
	{
		public void Configure(EntityTypeBuilder<ProductDetailInfoLocalizedEntity> builder)
		{
			builder.ToTable("ProductDetailInfosLocalized");
			builder.HasKey(prodDetInf => prodDetInf.Id);

			builder.Property(prodDetInf => prodDetInf.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(prodDetInf => prodDetInf.ProductDetailInfoId)
				.IsRequired();

			builder.Property(prodDetInf => prodDetInf.DetailedDescription)
			   .IsRequired();

			builder.Property(prodDetInf => prodDetInf.Parameters)
			   .IsRequired();

			builder.Property(prodDetInf => prodDetInf.Created)
				.IsRequired();

			builder.HasOne(prodDetInfl => prodDetInfl.ProductDetailInfo)
				.WithMany(prodDetInf => prodDetInf.Localizations)
				.HasForeignKey(prodDetInfl => prodDetInfl.ProductDetailInfoId);

			builder.HasOne(prodDetInfl => prodDetInfl.Language)
				.WithMany()
				.HasForeignKey(prodDetInfl => prodDetInfl.LanguageId);
		}
	}
}
