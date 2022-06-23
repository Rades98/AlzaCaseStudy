namespace CodeLists.OrderStatuses
{
    using System;

    public static class OrderStatuses
    {
        //When order is created, but still pending
        public const int New = 1;

        //Order is created and went to payment
        public const int Created = 2;

        //Order waits for payment
        public const int WaitingForPayment = 3;

        //Order is in expedition
        public const int InExpedition = 4;

        //Order is delivered
        public const int Delivered = 5;

        //Cancelled order
        public const int Canceled = 6;
    }
}
