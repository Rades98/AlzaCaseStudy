namespace DomainLayer.Entities
{
	using DomainLayer.Entities.LanguageMutations;

	public class AuditableLocalizableEntity : AuditableEntity
	{
		public int LanguageId { get; set; }
		public LanguageEntity Language { get; set; } = new();
	}
}
