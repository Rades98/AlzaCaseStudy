using DomainLayer.Entities.Orders.Localization;

namespace DomainLayer.Entities.Orders
{
    public class OrderStatusEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsOrderEditable { get; set; }
        public List<OrderEntity>? Orders { get; set; }
        public List<OrderStatusLocalizedEntity>? Localizations { get; set; }
    }
}
