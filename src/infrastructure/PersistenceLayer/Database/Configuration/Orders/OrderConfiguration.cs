namespace PersistenceLayer.Database.Configuration.Orders
{
    using DomainLayer.Entities.Orders;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(order => order.Id);

            builder.Property(order => order.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(order => order.Created)
                .IsRequired();

            builder.Property(order => order.OrderCode)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasIndex(order => order.OrderCode)
                .IsUnique();

            builder.Property(order => order.Total)
                .IsRequired();

            builder.Property(order => order.UserId)
                .IsRequired();

            builder.Property(order => order.OrderStatusId)
                .IsRequired();

            builder
                .HasMany(o => o.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            builder
                .HasOne(o => o.Status)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.OrderStatusId);

            builder
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId);
        }
    }
}


