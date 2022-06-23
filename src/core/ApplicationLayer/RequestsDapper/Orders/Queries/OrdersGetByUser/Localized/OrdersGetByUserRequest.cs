namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser.Localized
{
	using System.Linq.Expressions;
	using ApplicationLayer.Dtos;
	using Dapper;
	using DomainLayer.Entities.Orders;
	using MediatR;
	using PersistanceLayerDapper;
	using PersistanceLayerDapper.Extensions;
	using PersistanceLayerDapper.ProcedureModels.Orders;

	public class OrdersGetByUserRequest : IRequest<List<OrdersGetResponse>>
	{
		public int UserId { get; set; }
		public string LanguageCode { get; set; }
		public Expression<Func<OrderEntity, bool>> WhereFilter { get; set; } = x => true;

		public class Handler : IRequestHandler<OrdersGetByUserRequest, List<OrdersGetResponse>>
		{
			private readonly DapperContext _context;

			public Handler(DapperContext context) => _context = context;

			public async Task<List<OrdersGetResponse>> Handle(OrdersGetByUserRequest request, CancellationToken cancellationToken)
			{
				var procResult = await _context.ExecuteProcedureAsync<GetOrdersByUserModel>("[dbo].[GetOrdersByUserLocalized]", CreateProcedureParameters(request));

				return MapProcToResult(procResult);
			}

			private static DynamicParameters CreateProcedureParameters(OrdersGetByUserRequest request)
			{
				var parameters = new { @UserId = request.UserId, @LanguageCode = request.LanguageCode };
				var dynamicParameters = new DynamicParameters();
				dynamicParameters.AddDynamicParams(parameters);

				return dynamicParameters;
			}

			private static List<OrdersGetResponse> MapProcToResult(List<GetOrdersByUserModel> procResult)
			{
				var result = new List<OrdersGetResponse>();

				foreach (var group in procResult.GroupBy(x => x.OrderCode))
				{
					var orderItems = new List<OrderItemDto>();
					foreach(var item in group)
					{
						orderItems.Add(new()
						{
							Count = item.Count,
							Name = item.Name,
							Price = item.Price,
							ProductCode = item.ProductCode
						});
					}

					result.Add(new()
					{
						OrderCode = group.First().OrderCode,
						OrderStatus = group.First().OrderStatus,
						Total = group.First().Total,
						OrderItems = orderItems
					});
				}

				return result;
			}
		}
	}
}
