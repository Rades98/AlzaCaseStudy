namespace PersistenceLayer.Database.Configuration.Products
{
    using DomainLayer.Entities.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetailEntity>
    {
        public void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
        {
            builder.ToTable("ProductDetails");
            builder.HasKey(pd => pd.Id);

            builder.Property(pd => pd.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pd => pd.Created)
                .IsRequired();

            builder.Property(pd => pd.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(pd => pd.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(pd => pd.ImgUri)
                .IsRequired()
                .HasConversion(uriIn => uriIn.ToString(), utiOut => new Uri(utiOut));

            builder.Property(pd => pd.Description)
                .HasMaxLength(250);

            builder.Property(pd => pd.ProductCode)
                .HasMaxLength(8)
                .IsRequired();

            builder
                .HasOne(x => x.ProductCategory)
                .WithMany(x => x.ProductDetails)
                .HasForeignKey(x => x.ProductCategoryId);

            builder
                .HasIndex(p => p.ProductCode)
                .IsUnique();

            builder
                .HasOne(p => p.ProductDetailInfo)
                .WithOne(p => p.ProductDetail)
                .HasForeignKey<ProductDetailInfoEntity>(c => c.ProductDetailId);
        }
    }
}
