namespace DomainLayer.Entities.Orders
{
    using DomainLayer.Entities.Orders.Localization;

    public class OrderStatusEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsOrderEditable { get; set; }
        public IEnumerable<OrderEntity>? Orders { get; set; }
        public IEnumerable<OrderStatusLocalizedEntity>? Localizations { get; set; }
    }
}
