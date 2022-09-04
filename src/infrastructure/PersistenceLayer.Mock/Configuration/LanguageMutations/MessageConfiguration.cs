using DomainLayer.Entities.LanguageMutations;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.LanguageMutations
{
	internal static class MessageConfiguration
	{
		public static void ConfigureMessageEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MessageEntity>()
				.HasKey(msg => msg.Id);

			modelBuilder.Entity<MessageEntity>()
				.Property(msg => msg.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<MessageEntity>()
				.Property(msg => msg.Message)
				.IsRequired();

			modelBuilder.Entity<MessageEntity>()
				.Property(msg => msg.MessageCode)
				.IsRequired();

			modelBuilder.Entity<MessageEntity>()
				.Property(msg => msg.LanguageId)
				.IsRequired();

			modelBuilder.Entity<MessageEntity>()
				.Property(msg => msg.Created)
				.IsRequired();

			modelBuilder.Entity<MessageEntity>()
				.HasOne(msg => msg.MessageTypeEntity)
				.WithMany(msgt => msgt.Messages)
				.HasForeignKey(msg => msg.MessageTypeId);

			modelBuilder.Entity<MessageEntity>()
				.HasOne(msg => msg.Language)
				.WithMany()
				.HasForeignKey(msg => msg.LanguageId);
		}
	}
}
