namespace ApplicationLayer.Services.Orders.Commands.ChangeStatus
{
    public static class OrderChangeStatusCommandMessages
    {
        public static readonly string NotFound = "Order not found";
        public static readonly string WrongUser = "Wrong user";
        public static readonly string StatusChanged = "Order status changed";
        public static readonly string Error = "Order status update failed";
    }
}
