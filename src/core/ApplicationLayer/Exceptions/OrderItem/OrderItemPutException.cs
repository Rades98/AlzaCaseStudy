namespace ApplicationLayer.Exceptions.OrderItem
{
    public class OrderItemPutException : Exception
    {
        public OrderItemPutException()
        {
        }

        public OrderItemPutException(string message)
        : base(message)
        {
        }

        public OrderItemPutException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
