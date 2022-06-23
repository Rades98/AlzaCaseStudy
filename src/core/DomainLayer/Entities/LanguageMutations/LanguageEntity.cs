namespace DomainLayer.Entities.Texts
{
	public class LanguageEntity : AuditableEntity
	{
		public string Name { get; set; } = String.Empty;

		// ISO639.2 language code
		public string Code { get; set; } = String.Empty;
	}
}
