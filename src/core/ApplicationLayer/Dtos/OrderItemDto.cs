namespace ApplicationLayer.Dtos
{
	public class OrderItemDto : RestDtoBase
	{
		public string Name { get; set; } = string.Empty;
		public Decimal Price { get; set; }
		public int Count { get; set; }
		public string ProductCode { get; set; } = string.Empty;
	}
}
