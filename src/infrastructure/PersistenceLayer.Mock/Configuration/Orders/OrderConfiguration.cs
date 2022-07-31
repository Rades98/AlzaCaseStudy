namespace PersistenceLayer.Mock.Configuration.Orders
{
	using DomainLayer.Entities.Orders;
	using Microsoft.EntityFrameworkCore;

	internal static class OrderConfiguration
	{
		public static void ConfigureOrderEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderEntity>()
				.HasKey(order => order.Id);

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.Created)
				.IsRequired();

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.OrderCode)
				.HasMaxLength(10)
				.IsRequired();

			modelBuilder.Entity<OrderEntity>()
				.HasIndex(order => order.OrderCode)
				.IsUnique();

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.Total)
				.IsRequired();

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.UserId)
				.IsRequired();

			modelBuilder.Entity<OrderEntity>()
				.Property(order => order.OrderStatusId)
				.IsRequired();

			modelBuilder.Entity<OrderEntity>()
				.HasMany(o => o.Items)
				.WithOne(o => o.Order)
				.HasForeignKey(o => o.OrderId);

			modelBuilder.Entity<OrderEntity>()
				.HasOne(o => o.Status)
				.WithMany(o => o.Orders)
				.HasForeignKey(o => o.OrderStatusId);

			modelBuilder.Entity<OrderEntity>()
				.HasOne(o => o.User)
				.WithMany(o => o.Orders)
				.HasForeignKey(o => o.UserId);
		}
	}
}


