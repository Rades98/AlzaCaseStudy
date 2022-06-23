using DomainLayer.Entities.Users;

namespace DomainLayer.Entities.Orders
{
    public class OrderEntity : AuditableEntity
    {
        public string OrderCode { get; set; } = string.Empty;
        public decimal Total { get; set; } = decimal.Zero;
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public ICollection<OrderItemEntity>? Items {get; set;}
        public OrderStatusEntity Status { get; set; } = new();
        public UserEntity User { get; set; } = new();
    }
}
