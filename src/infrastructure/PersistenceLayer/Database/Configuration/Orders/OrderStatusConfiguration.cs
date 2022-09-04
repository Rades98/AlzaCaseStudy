using DomainLayer.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Orders
{
	internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatusEntity>
	{
		public void Configure(EntityTypeBuilder<OrderStatusEntity> builder)
		{
			builder.ToTable("OrderStatuses");
			builder.HasKey(orderStatus => orderStatus.Id);

			builder.Property(orderStatus => orderStatus.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(orderStatus => orderStatus.Name)
				.IsRequired();

			builder.Property(orderStatus => orderStatus.Created)
				.IsRequired();
		}
	}
}
