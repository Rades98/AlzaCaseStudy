namespace ApplicationLayer.Exceptions.OrderItem
{
    public class OrderItemDeleteException : Exception
    {
        public OrderItemDeleteException()
        {
        }

        public OrderItemDeleteException(string message)
        : base(message)
        {
        }

        public OrderItemDeleteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
