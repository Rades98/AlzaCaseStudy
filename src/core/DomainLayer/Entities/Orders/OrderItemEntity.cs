using DomainLayer.Entities.Product;

namespace DomainLayer.Entities.Orders
{
    public class OrderItemEntity : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; } = new();
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = new();
    }
}
