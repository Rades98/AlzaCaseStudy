namespace DomainLayer.Entities.Users
{
	public class UserRoleEntity : AuditableEntity
	{
		public string Name { get; set; } = string.Empty;
		public virtual IEnumerable<UserEntity>? Users { get; set; }
		public virtual IEnumerable<UserRoleRelationEntity>? UserRelations { get; set; }
	}
}
