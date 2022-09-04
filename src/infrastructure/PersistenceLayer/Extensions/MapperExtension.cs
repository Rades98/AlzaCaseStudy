namespace PersistenceLayer.Extensions
{
	using DomainLayer.Entities.Orders;
	using DomainLayer.Entities.Product;
	using PersistanceLayer.Contracts.Models.Orders;
	using PersistanceLayer.Contracts.Models.ProductDetailInfos;

	public static class MapperExtension
	{
		public static ProductDetailInfoModel MapToModel(this ProductDetailInfoEntity ent)
		{
			return new()
			{
				DetailedDescription = ent.DetailedDescription,
				Parameters = ent.Parameters,
				ProductDetailId = ent.ProductDetailId,
				Id = ent.Id,
				ProductCode = ent.ProductDetail!.ProductCode
			};
		}

		public static List<OrderModel> MapToModel(this List<OrderEntity> orders)
		{
			var result = new List<OrderModel>();

			orders.ForEach(order =>
			{
				var ord = new OrderModel()
				{
					OrderCode = order.OrderCode,
					Total = order.Total,
					OrderStatusId = order.OrderStatusId
				};

				order.Items!.Where(p => p.Product != null && p.Product.ProductDetail != null).ToList().ForEach(p =>
				{
					var detail = p.Product!.ProductDetail!;

					var opt = ord.OrderItems.FirstOrDefault(x => x.ProductCode == detail.ProductCode);

					if (opt is not null)
					{
						opt.Count++;
					}
					else
					{
						ord.OrderItems.Add(new OrderItemModel()
						{
							Name = detail.Name,
							Price = detail.Price,
							ProductCode = detail.ProductCode,
							Count = 1
						});
					}
				});

				result.Add(ord);
			});

			return result;
		}
	}
}
