using DomainLayer.Entities.Product;

namespace DomainLayer.Entities.Orders
{
    public class OrderItemEntity : AuditableEntity
    {
        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
