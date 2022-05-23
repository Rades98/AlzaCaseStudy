namespace DomainLayer.Entities.Users
{
    public class UserEntity : AuditableEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[64];
        public byte[] PasswordSalt { get; set; } = new byte[64];
        public string Email { get; set; } = string.Empty;
        public IEnumerable<UserRoleEntity>? Roles { get; set; }
        public IEnumerable<UserRoleRelationEntity>? RoleRelations { get; set; }
    }
}
