namespace ApplicationLayer.Services.OrderItems.Commands.Put
{
    public class OrderItemPutRequestMessages
    {
        public const string ProductNotFound = "Product not found";
        public const string OrderNotFound = "Order not found";
        public const string OrderUneditable = "Order can not be updated";
        public const string ProductAdded = "Product added to order";
        public const string AdditionFailed = "Product addition to order failed";
    }
}
