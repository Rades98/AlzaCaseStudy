using DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Users
{
	public static class UserRegistrationConfiguration
	{
		public static void ConfigureUserRegistrationEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRegistrationEntity>()
				.HasKey(user => user.Id);

			modelBuilder.Entity<UserRegistrationEntity>()
				.Property(userReg => userReg.Code)
				.HasMaxLength(200)
				.IsRequired();

			modelBuilder.Entity<UserRegistrationEntity>()
				.Property(userReg => userReg.LinkActiveTill)
				.IsRequired();

			modelBuilder.Entity<UserRegistrationEntity>()
				.HasOne(userReg => userReg.User)
				.WithOne(user => user.Registration)
				.HasForeignKey<UserEntity>(user => user.RegistrationId);
		}
	}
}
