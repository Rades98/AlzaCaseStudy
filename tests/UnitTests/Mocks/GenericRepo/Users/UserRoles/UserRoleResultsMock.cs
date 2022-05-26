namespace UnitTests.Mocks.GenericRepo.Users.UserRoles
{
    using DomainLayer.Entities.Users;
    using System.Collections.Generic;

    public static class UserRoleResultsMock
    {
        public static UserRoleEntity TestRole => _testRole;

        public static readonly List<UserRoleEntity> Roles = new()
        {
            TestRole
        };

        private static UserRoleEntity _testRole => new()
        {
            Id = System.Guid.NewGuid(),
            Name = UserRolesCodeList.UserRoles.Admin,
            Created = System.DateTime.Now
        };
    }
}
