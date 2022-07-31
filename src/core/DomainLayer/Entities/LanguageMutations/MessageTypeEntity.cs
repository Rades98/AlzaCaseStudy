namespace DomainLayer.Entities.LanguageMutations
{
	public class MessageTypeEntity : AuditableEntity
	{
		public string Name { get; set; } = string.Empty;
		public virtual IEnumerable<MessageEntity>? Messages { get; set; }
	}
}
