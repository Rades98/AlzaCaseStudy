namespace PersistenceLayer.Mock.Configuration.Users
{
	using DomainLayer.Entities.Users;
	using Microsoft.EntityFrameworkCore;

	public static class UserRoleConfiguration
	{
		public static void ConfigureUserRoleEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRoleEntity>()
				.HasKey(user => user.Id);

			modelBuilder.Entity<UserRoleEntity>()
				.Property(user => user.Id)
				.IsRequired();

			modelBuilder.Entity<UserRoleEntity>()
				.Property(user => user.Created)
				.IsRequired();

			modelBuilder.Entity<UserRoleEntity>()
				.Property(user => user.Name)
				.HasMaxLength(50)
				.IsRequired();
		}
	}
}
