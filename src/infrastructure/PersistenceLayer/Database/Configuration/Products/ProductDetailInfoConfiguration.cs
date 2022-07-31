namespace PersistenceLayer.Database.Configuration.Products
{
    using DomainLayer.Entities.Product;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class  ProductDetailInfoConfiguration : IEntityTypeConfiguration<ProductDetailInfoEntity>
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
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(pd => pd.Parameters)
                .HasMaxLength(5000)
                .IsRequired();

            builder.HasOne(p => p.ProductDetail)
                .WithOne(p => p.ProductDetailInfo)
                .HasForeignKey<ProductDetailEntity>(c => c.Id);
        }
    }
}
