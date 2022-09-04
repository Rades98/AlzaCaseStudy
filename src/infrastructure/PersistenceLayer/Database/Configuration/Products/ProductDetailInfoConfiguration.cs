using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Products
{
	internal class ProductDetailInfoConfiguration : IEntityTypeConfiguration<ProductDetailInfoEntity>
	{
		public void Configure(EntityTypeBuilder<ProductDetailInfoEntity> builder)
		{
			builder.ToTable("ProductDetailInfos");
			builder.HasKey(pd => pd.Id);

			builder.Property(pd => pd.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(pd => pd.Created)
				.IsRequired();

			builder.Property(pd => pd.DetailedDescription)
				.HasMaxLength(50000)
				.IsRequired();

			builder.Property(pd => pd.Parameters)
				.HasMaxLength(50000)
				.IsRequired();
		}
	}
}
