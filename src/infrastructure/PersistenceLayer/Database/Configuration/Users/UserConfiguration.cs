namespace PersistenceLayer.Database.Configuration.Users
{
    using DomainLayer.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(user => user.Created)
                .IsRequired();

            builder.Property(user => user.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(user => user.IsActive)
               .IsRequired();

            builder.Property(user => user.PasswordHash)
                .HasColumnType("varbinary")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(user => user.PasswordSalt)
                .HasColumnType("varbinary")
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(r => r.Roles)
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

            builder.HasOne(user => user.Registration)
                .WithOne(userReg => userReg.User);
        }
    }
}
