namespace DomainLayer.Entities.Users
{
    public class UserRoleRelationEntity : AuditableEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = new();
        public Guid RoleId { get; set; }
        public UserRoleEntity Role { get; set; } = new();
    }
}
