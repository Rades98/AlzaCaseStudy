namespace OrderStatusCodeList
{
    public static class OrderStatuses
    {
        //When order is created, but still pending
        public static readonly Guid New = new("27F83608-434A-4F4B-8315-FF711A97BFF4");

        //Order is created and went to payment
        public static readonly Guid Created = new("93623D0A-914E-4252-9C1F-89563B4F9EE2");

        //Order waits for payment
        public static readonly Guid WaitingForPayment = new("C958DDEC-C8C3-410D-8FB3-7BBA41B9CDD8");

        //Order is in expedition
        public static readonly Guid InExpedition = new("91BA34E8-3BF7-4168-9E59-BB68642F602E");

        //Order is delivered
        public static readonly Guid Delivered = new("953FF38D-BA59-41FE-9246-594D6AF35B1F");

    }
}
