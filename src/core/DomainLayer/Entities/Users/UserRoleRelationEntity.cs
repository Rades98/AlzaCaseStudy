namespace DomainLayer.Entities.Users
{
    public class UserRoleRelationEntity : AuditableEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; } = new();
        public int RoleId { get; set; }
        public UserRoleEntity Role { get; set; } = new();
    }
}
