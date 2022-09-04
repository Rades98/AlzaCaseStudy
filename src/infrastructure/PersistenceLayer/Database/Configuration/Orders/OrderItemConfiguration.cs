using DomainLayer.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Orders
{
	internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
	{
		public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
		{
			builder.ToTable("OrderItems");
			builder.HasKey(orderItem => orderItem.Id);

			builder.Property(orderItem => orderItem.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(orderItem => orderItem.OrderId)
				.IsRequired();

			builder.Property(orderItem => orderItem.ProductId)
				.IsRequired();

			builder.Property(orderItem => orderItem.Created)
				.IsRequired();
		}
	}
}


