using DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceLayer.Database.Configuration.Users
{
	internal class UserRegistrationConfiguration : IEntityTypeConfiguration<UserRegistrationEntity>
	{
		public void Configure(EntityTypeBuilder<UserRegistrationEntity> builder)
		{
			builder.ToTable("UserRegistrations");
			builder.HasKey(userReg => userReg.Id);

			builder.Property(userReg => userReg.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(userReg => userReg.Code)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(userReg => userReg.LinkActiveTill)
				.IsRequired();

			builder.HasOne(userReg => userReg.User)
				.WithOne(user => user.Registration)
				.HasForeignKey<UserEntity>(user => user.RegistrationId);
		}
	}
}
