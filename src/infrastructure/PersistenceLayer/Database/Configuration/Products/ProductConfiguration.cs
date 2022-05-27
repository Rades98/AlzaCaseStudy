namespace PersistenceLayer.Database.Configuration.Products
{
    using DomainLayer.Entities.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(product => product.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(product => product.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(product => product.ImgUri)
                .IsRequired()
                .HasConversion(uriIn => uriIn.ToString(), utiOut => new Uri(utiOut));

            builder.Property(product => product.Description)
                .HasMaxLength(250);

            builder.Property(product => product.ProductCode)
                .HasMaxLength(8)
                .IsRequired();

            builder
                .HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCategoryId);
        }
    }
}
