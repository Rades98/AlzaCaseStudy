namespace DomainLayer.Entities.Orders
{
    public class OrderStatusEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<OrderEntity>? Orders { get; set; }
    }
}
