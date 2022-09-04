using DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Mock.Configuration.Users
{
	public static class UserConfiguration
	{
		public static void ConfigureUserEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserEntity>()
				.HasKey(user => user.Id);

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.Created)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.Name)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.Surname)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.Email)
				.HasMaxLength(50)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.UserName)
				.HasMaxLength(20)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.PasswordHash)
				.HasColumnType("varbinary")
				.HasMaxLength(64)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.PasswordSalt)
				.HasColumnType("varbinary")
				.HasMaxLength(128)
				.IsRequired();

			modelBuilder.Entity<UserEntity>()
				.Property(user => user.IsActive)
			   .IsRequired();

			modelBuilder.Entity<UserEntity>()
				.HasMany(r => r.Roles)
				.WithMany(u => u.Users)
				.UsingEntity<UserRoleRelationEntity>(
				j => j
					.HasOne(urr => urr.Role)
					.WithMany(ur => ur.UserRelations)
					.HasForeignKey(pt => pt.RoleId),
				j => j
					.HasOne(pt => pt.User)
					.WithMany(p => p.RoleRelations)
					.HasForeignKey(pt => pt.UserId),
				j =>
				{
					j.Property(pt => pt.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
					j.HasKey(t => new { t.RoleId, t.UserId });
				});

			modelBuilder.Entity<UserEntity>()
				.HasOne(user => user.Registration)
				.WithOne(userReg => userReg.User);
		}
	}
}
