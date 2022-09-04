using DomainLayer.Entities.LanguageMutations;
using Microsoft.EntityFrameworkCore;


namespace PersistenceLayer.Mock.Configuration.LanguageMutations
{
	internal static class LanguageConfiguration
	{
		public static void ConfigureLanguageEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LanguageEntity>()
				.HasKey(language => language.Id);

			modelBuilder.Entity<LanguageEntity>()
				.Property(language => language.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<LanguageEntity>()
				.Property(language => language.Name)
				.IsRequired();

			modelBuilder.Entity<LanguageEntity>()
				.Property(language => language.Code)
				.IsFixedLength(true)
				.HasMaxLength(2)
				.IsRequired();

			modelBuilder.Entity<LanguageEntity>()
				.Property(language => language.Created)
				.IsRequired();

			var languages = new List<LanguageEntity>()
			{
				new() {Name="Čeština", Code="cs", Id = CodeLists.Languages.Languages.CZLanguage, Created = DateTime.Now },
				new() {Name="English", Code="en", Id = CodeLists.Languages.Languages.ENLanguage, Created = DateTime.Now },
				new() {Name="Slovenčina", Code="sk", Id = CodeLists.Languages.Languages.SKLanguage, Created = DateTime.Now },
				new() {Name="Polski", Code="pl", Id = CodeLists.Languages.Languages.PLLanguage, Created = DateTime.Now },
				new() {Name="Deutsch", Code="de", Id = CodeLists.Languages.Languages.DELanguage, Created = DateTime.Now },
				new() {Name="Français", Code="fe", Id = CodeLists.Languages.Languages.FELanguage, Created = DateTime.Now },
			};

			modelBuilder.Entity<LanguageEntity>()
				.HasData(languages);

			//Relations for language are not necessary - it would be complicated
		}
	}
}
