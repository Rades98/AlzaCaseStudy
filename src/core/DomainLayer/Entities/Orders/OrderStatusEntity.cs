namespace DomainLayer.Entities.Orders
{
    using DomainLayer.Entities.Orders.Localization;

    public class OrderStatusEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsOrderEditable { get; set; }
        public List<OrderEntity>? Orders { get; set; }
        public List<OrderStatusLocalizedEntity>? Localizations { get; set; }
    }
}
