namespace PersistenceLayer.Database.Configuration.Orders
{
    using DomainLayer.Entities.Orders;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatusEntity>
    {
        public void Configure(EntityTypeBuilder<OrderStatusEntity> builder)
        {
            builder.ToTable("OrderStatuses");
            builder.HasKey(orderItem => orderItem.Id);

            builder.Property(orderItem => orderItem.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(orderItem => orderItem.Name)
                .IsRequired();
        }
    }
}
