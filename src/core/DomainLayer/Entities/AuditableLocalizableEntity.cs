using DomainLayer.Entities.LanguageMutations;

namespace DomainLayer.Entities
{
	public class AuditableLocalizableEntity : AuditableEntity
	{
		public int LanguageId { get; set; }
		public LanguageEntity Language { get; set; } = new();
	}
}
