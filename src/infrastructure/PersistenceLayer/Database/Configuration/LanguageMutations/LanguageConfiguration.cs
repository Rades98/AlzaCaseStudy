using DomainLayer.Entities.LanguageMutations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.LanguageMutations
{
	internal class LanguageConfiguration : IEntityTypeConfiguration<LanguageEntity>
	{
		public void Configure(EntityTypeBuilder<LanguageEntity> builder)
		{
			builder.ToTable("Languages");
			builder.HasKey(language => language.Id);

			builder.Property(language => language.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(language => language.Name)
				.IsRequired();

			builder.Property(language => language.Code)
				.IsFixedLength(true)
				.HasMaxLength(2)
				.IsRequired();

			builder.Property(language => language.Created)
				.IsRequired();

			//Relations for language are not necessary - it would be complicated
		}
	}
}
