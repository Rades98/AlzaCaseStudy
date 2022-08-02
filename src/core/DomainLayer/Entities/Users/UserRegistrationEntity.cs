namespace DomainLayer.Entities.Users
{
	public class UserRegistrationEntity : AuditableEntity
	{
		public UserEntity? User { get; set; }
		public DateTime LinkActiveTill { get; set; }
		public string Code { get; set; } = string.Empty;
	}
}
