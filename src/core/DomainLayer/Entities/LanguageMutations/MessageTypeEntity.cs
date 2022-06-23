namespace DomainLayer.Entities.LanguageMutations
{
	public class MessageTypeEntity : AuditableEntity
	{
		public string Name { get; set; } = string.Empty;
		public IEnumerable<MessageEntity>? Messages { get; set; }
	}
}
