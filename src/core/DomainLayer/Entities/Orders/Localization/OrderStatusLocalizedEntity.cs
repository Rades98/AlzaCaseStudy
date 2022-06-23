namespace DomainLayer.Entities.Orders.Localization
{
	public class OrderStatusLocalizedEntity : AuditableLocalizableEntity
	{
		public string Name { get; set; } = string.Empty;
		public int OrderStatusId { get; set; }
		public OrderStatusEntity OrderStatus { get; set; } = new();
	}
}
