namespace DomainLayer.Entities.Orders
{
    public class OrderEntity : AuditableEntity
    {
        public string OrderCode { get; set; } = string.Empty;
        public decimal Total { get; set; } = decimal.Zero;
        public Guid UserId { get; set; }
        public Guid OrderStatusId { get; set; }
        public IEnumerable<OrderItemEntity>? Items {get; set;}
        public OrderStatusEntity Status { get; set; } = new();
    }
}
