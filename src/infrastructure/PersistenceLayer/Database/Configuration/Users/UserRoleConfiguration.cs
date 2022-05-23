namespace PersistenceLayer.Database.Configuration.Users
{
    using DomainLayer.Entities.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .IsRequired();

            builder.Property(user => user.Created)
                .IsRequired();

            builder.Property(user => user.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
