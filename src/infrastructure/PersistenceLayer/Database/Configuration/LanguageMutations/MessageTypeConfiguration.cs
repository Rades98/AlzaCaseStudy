namespace PersistenceLayer.Database.Configuration.LanguageMutations
{
	using DomainLayer.Entities.LanguageMutations;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class MessageTypeConfiguration : IEntityTypeConfiguration<MessageTypeEntity>
	{
		public void Configure(EntityTypeBuilder<MessageTypeEntity> builder)
		{
			builder.ToTable("MessageTypes");
			builder.HasKey(msg => msg.Id);

			builder.Property(msg => msg.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(msg => msg.Name)
				.IsRequired();

			builder.Property(msg => msg.Created)
				.IsRequired();
		}
	}
}
