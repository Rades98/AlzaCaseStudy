using DomainLayer.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Orders
{
	internal static class OrderItemConfiguration
	{
		public static void ConfigureOrderItemEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItemEntity>()
				.HasKey(orderItem => orderItem.Id);

			modelBuilder.Entity<OrderItemEntity>()
				.Property(orderItem => orderItem.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<OrderItemEntity>()
				.Property(orderItem => orderItem.OrderId)
				.IsRequired();

			modelBuilder.Entity<OrderItemEntity>()
				.Property(orderItem => orderItem.ProductId)
				.IsRequired();

			modelBuilder.Entity<OrderItemEntity>()
				.Property(orderItem => orderItem.Created)
				.IsRequired();
		}
	}
}


