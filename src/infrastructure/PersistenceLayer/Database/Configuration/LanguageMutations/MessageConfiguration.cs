using DomainLayer.Entities.LanguageMutations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.LanguageMutations
{
	internal class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
	{
		public void Configure(EntityTypeBuilder<MessageEntity> builder)
		{
			builder.ToTable("Messages");
			builder.HasKey(msg => msg.Id);

			builder.Property(msg => msg.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(msg => msg.Message)
				.IsRequired();

			builder.Property(msg => msg.MessageCode)
				.IsRequired();

			builder.Property(msg => msg.LanguageId)
				.IsRequired();

			builder.Property(msg => msg.Created)
				.IsRequired();

			builder.HasOne(msg => msg.MessageTypeEntity)
				.WithMany(msgt => msgt.Messages)
				.HasForeignKey(msg => msg.MessageTypeId);

			builder.HasOne(msg => msg.Language)
				.WithMany()
				.HasForeignKey(msg => msg.LanguageId);
		}
	}
}
