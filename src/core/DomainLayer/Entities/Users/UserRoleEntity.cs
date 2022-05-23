namespace DomainLayer.Entities.Users
{
    public class UserRoleEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UserEntity>? Users { get; set; }
        public IEnumerable<UserRoleRelationEntity>? UserRelations { get; set; }
    }
}
