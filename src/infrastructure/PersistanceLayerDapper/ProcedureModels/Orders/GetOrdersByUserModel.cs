namespace PersistanceLayerDapper.ProcedureModels.Orders
{
	public class GetOrdersByUserModel
	{
		public string OrderCode { get; set; } = string.Empty;
		public decimal Total { get; set; }
		public string OrderStatus { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Count { get; set; }
		public string ProductCode { get; set; } = string.Empty;
	}
}
