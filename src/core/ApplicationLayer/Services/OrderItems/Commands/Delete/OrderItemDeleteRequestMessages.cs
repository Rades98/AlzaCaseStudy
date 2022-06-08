namespace ApplicationLayer.Services.OrderItems.Commands.Delete
{
    public static class OrderItemDeleteRequestMessages
    {
        public const string NotFound = "Order item not found";
        public const string Error = "Error while deleting";
        public const string Ok = "Order item has been deleted";
    }
}
