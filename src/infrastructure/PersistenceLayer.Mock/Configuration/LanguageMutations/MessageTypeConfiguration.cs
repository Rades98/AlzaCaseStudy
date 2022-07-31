namespace PersistenceLayer.Mock.Configuration.LanguageMutations
{
	using CodeLists.MessageTypes;
	using DomainLayer.Entities.LanguageMutations;
	using Microsoft.EntityFrameworkCore;

	internal static class MessageTypeConfiguration
	{
		public static void ConfigureMessageTypeEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MessageTypeEntity>()
				.HasKey(msg => msg.Id);

			modelBuilder.Entity<MessageTypeEntity>()
				.Property(msg => msg.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<MessageTypeEntity>()
				.Property(msg => msg.Name)
				.IsRequired();

			modelBuilder.Entity<MessageTypeEntity>()
				.Property(msg => msg.Created)
				.IsRequired();

			var messageTypes = new List<MessageTypeEntity>()
			{
				new() { Name = "Info", Id = MessagTypes.Info, Created = DateTime.Now },
				new() { Name = "Hint", Id = MessagTypes.Hint, Created = DateTime.Now },
				new() { Name = "Error", Id = MessagTypes.Error, Created = DateTime.Now },
			};

			modelBuilder.Entity<MessageTypeEntity>()
				.HasData(messageTypes);
		}
	}
}
