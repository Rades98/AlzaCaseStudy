namespace PersistenceLayer.Mock.Configuration.Orders.Localization
{
	using DomainLayer.Entities.Orders.Localization;
	using Microsoft.EntityFrameworkCore;

	internal static class OrderStatusLocalizedConfiguration
	{
		public static void ConfigureOrderStatusLocalizedEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.HasKey(ordStat => ordStat.Id);

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.Property(ordStat => ordStat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.Property(ordStat => ordStat.OrderStatusId)
				.IsRequired();

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.Property(ordStat => ordStat.Name)
			   .IsRequired();

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.Property(ordStat => ordStat.Created)
				.IsRequired();

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.HasOne(ordStatl => ordStatl.OrderStatus)
				.WithMany(ordStat => ordStat.Localizations)
				.HasForeignKey(ordStatl => ordStatl.OrderStatusId);

			modelBuilder.Entity<OrderStatusLocalizedEntity>()
				.HasOne(ordStatl => ordStatl.Language)
				.WithMany()
				.HasForeignKey(ordStatl => ordStatl.LanguageId);
		}
	}
}
