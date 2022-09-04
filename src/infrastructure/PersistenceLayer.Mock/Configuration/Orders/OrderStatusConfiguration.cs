using DomainLayer.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Orders
{
	internal static class OrderStatusConfiguration
	{
		public static void ConfigureOrderStatusEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderStatusEntity>()
				.HasKey(orderStatus => orderStatus.Id);

			modelBuilder.Entity<OrderStatusEntity>()
				.Property(orderStatus => orderStatus.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<OrderStatusEntity>()
				.Property(orderStatus => orderStatus.Name)
				.IsRequired();

			modelBuilder.Entity<OrderStatusEntity>()
				.Property(orderStatus => orderStatus.Created)
				.IsRequired();
		}
	}
}
