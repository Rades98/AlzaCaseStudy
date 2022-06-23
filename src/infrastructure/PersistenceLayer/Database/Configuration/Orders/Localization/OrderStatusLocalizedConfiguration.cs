namespace PersistenceLayer.Database.Configuration.Orders.Localization
{
	using DomainLayer.Entities.Orders.Localization;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class OrderStatusLocalizedConfiguration : IEntityTypeConfiguration<OrderStatusLocalizedEntity>
	{
		public void Configure(EntityTypeBuilder<OrderStatusLocalizedEntity> builder)
		{
			builder.ToTable("OrderStatusesLocalized");
			builder.HasKey(ordStat => ordStat.Id);

			builder.Property(ordStat => ordStat.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(ordStat => ordStat.OrderStatusId)
				.IsRequired();

			builder.Property(ordStat => ordStat.Name)
			   .IsRequired();

			builder.Property(ordStat => ordStat.Created)
				.IsRequired();

			builder.HasOne(ordStatl => ordStatl.OrderStatus)
				.WithMany(ordStat => ordStat.Localizations)
				.HasForeignKey(ordStatl => ordStatl.OrderStatusId);

			builder.HasOne(ordStatl => ordStatl.Language)
				.WithMany()
				.HasForeignKey(ordStatl => ordStatl.LanguageId);
		}
	}
}
