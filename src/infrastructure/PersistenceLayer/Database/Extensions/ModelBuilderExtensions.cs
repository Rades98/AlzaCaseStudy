namespace PersistenceLayer.Database.Extensions
{
    using ApplicationLayer.Utils.PasswordHashing;
    using DomainLayer.Entities.Product;
    using DomainLayer.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    internal static class ModelBuilderExtensions
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {           
            var userRoles = new List<UserRoleEntity>()
            {
                new UserRoleEntity()
                {
                    Id = new Guid("7CFD3E28-C6ED-48B9-8D08-424751E77EAF"),
                    Name = UserRolesCodeList.UserRoles.Admin,
                    Created = _created
                }
            };

            // Admin
            // aJc48262_1Kjkz>X!
            PasswordHashing.CreatePasswordHash("aJc48262_1Kjkz>X!", out byte[] pwHash, out byte[] pwSalt);

            var users = new List<UserEntity>()
            {
                new()
                {
                    Id=new Guid("1D984227-1A68-4AA2-98FE-8C398E02FF85"),
                    Name = "Admin",
                    UserName = "Admin",
                    Surname = "Admin",
                    PasswordHash = pwHash,
                    PasswordSalt = pwSalt,
                    Email = "some@email.com",
                    Created = _created
                }
            };

            //Add user roles
            modelBuilder.Entity<UserRoleEntity>()
                .HasData(userRoles);

            //Add user
            modelBuilder.Entity<UserEntity>()
                .HasData(users);

            return modelBuilder;
        }
    }
}
