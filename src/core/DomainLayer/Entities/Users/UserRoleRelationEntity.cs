namespace DomainLayer.Entities.Users
{
	public class UserRoleRelationEntity : AuditableEntity
	{
		public int UserId { get; set; }
		public virtual UserEntity? User { get; set; }
		public int RoleId { get; set; }
		public virtual UserRoleEntity? Role { get; set; }
	}
}
