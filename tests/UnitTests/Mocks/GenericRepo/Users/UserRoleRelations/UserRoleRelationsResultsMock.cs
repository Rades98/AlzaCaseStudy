namespace UnitTests.Mocks.GenericRepo.Users.UserRoleRelations
{
    using DomainLayer.Entities.Users;
    using System.Collections.Generic;
    using UserRoles;

    public static class UserRoleRelationsResultsMock
    {
        public static readonly List<UserRoleRelationEntity> RoleRelations = new()
        {
            new()
            {
                Id = System.Guid.NewGuid(),
                UserId = UsersRepositoryResultsMock.TestUser.Id,
                RoleId = UserRoleResultsMock.TestRole.Id
            }
        };
    }
}
