namespace DomainLayer.Entities
{
	using DomainLayer.Entities.Texts;

	public class AuditableLocalizableEntity : AuditableEntity
	{
		public int LanguageId { get; set; }
		public LanguageEntity Language { get; set; } = new();
	}
}
