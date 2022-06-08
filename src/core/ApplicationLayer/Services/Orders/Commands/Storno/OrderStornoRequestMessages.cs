namespace ApplicationLayer.Services.Orders.Commands.Storno
{
    public static class OrderStornoRequestMessages
    {
        public const string NotFound = "Order not found";
        public const string Error = "Storno failed";
        public const string CannotBeCanceled = "Order cannot be canceled";
    }
}
