using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Products
{
	internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
	{
		public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
		{
			builder.ToTable("ProductCategories");
			builder.HasKey(productCategory => productCategory.Id);

			builder.Property(productCategory => productCategory.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(productCategory => productCategory.Created)
				.IsRequired();

			builder.Property(productCategory => productCategory.Name)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(productCategory => productCategory.Description)
				.HasMaxLength(250);

			builder
				.HasOne(pc => pc.ParentProductCategory)
				.WithMany(pc => pc.ChildrenCategories)
				.HasForeignKey(pc => pc.ParentProductCategoryId);
		}
	}
}
