using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Products
{
	internal class ProductConfigurations : IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.ToTable("Products");
			builder.HasKey(product => product.Id);

			builder.Property(product => product.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(product => product.Created)
				.IsRequired();

			builder
				.HasOne(product => product.ProductDetail)
				.WithMany(pd => pd.Products)
				.HasForeignKey(product => product.ProductDetailId);
		}
	}
}
