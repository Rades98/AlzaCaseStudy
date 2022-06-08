namespace ApplicationLayer.Exceptions.Order
{
    public class OrderDeleteException : Exception
    {
        public OrderDeleteException()
        {
        }

        public OrderDeleteException(string message)
        : base(message)
        {
        }

        public OrderDeleteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
