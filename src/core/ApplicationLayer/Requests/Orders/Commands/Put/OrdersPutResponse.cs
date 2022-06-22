namespace ApplicationLayer.Requests.Orders.Commands.Put
{
	public class OrdersPutResponse
	{
		public string Message { get; set; } = string.Empty;
		public string OrderCode { get; set; } = string.Empty;
		public Guid OrderId { get; set; }
	}
}
