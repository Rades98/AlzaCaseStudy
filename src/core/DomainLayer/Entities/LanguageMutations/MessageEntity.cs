namespace DomainLayer.Entities.LanguageMutations
{
	public class MessageEntity : AuditableLocalizableEntity
	{
		public string MessageCode { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public int MessageTypeId { get; set; }
		public virtual MessageTypeEntity MessageTypeEntity { get; set; } = new();
	}
}
