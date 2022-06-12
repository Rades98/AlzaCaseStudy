namespace ApplicationLayer.Services.Orders.Queries
{
    using DomainLayer.Entities.Orders;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class OrdersGetByUserRequest : IRequest<List<OrdersGetResponse>>
    {
        public Guid UserId { get; set; }
        public Expression<Func<OrderEntity, bool>> WhereFilter { get; set; } = x => true;

        public class Handler : IRequestHandler<OrdersGetByUserRequest, List<OrdersGetResponse>>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<List<OrdersGetResponse>> Handle(OrdersGetByUserRequest request, CancellationToken cancellationToken)
            {
                var result = new List<OrdersGetResponse>();

                Expression<Func<OrderEntity, bool>> exp = x => x.UserId == request.UserId;

                var orders = await _dbContext.Orders
                    .Include(i => i.Status)
                    .Include(i => i.Items)
                        .ThenInclude(i => i.Product)
                            .ThenInclude(i => i.ProductDetail)
                    .AsNoTracking()
                    .Where(exp)
                    .Where(request.WhereFilter)
                    .ToListAsync(cancellationToken);

                foreach (var order in orders)
                {
                    var response = new OrdersGetResponse
                    {
                        OrderCode = order.OrderCode,
                        OrderStatus = order.Status.Name,
                        Total = order.Total,
                    };

                    order.Items!.ToList().ForEach(p =>
                    {
                        var detail = p.Product.ProductDetail;

                        var opt = response.OrderItems.FirstOrDefault(x => x.ProductCode == detail.ProductCode);

                        if (opt is not null)
                        {
                            opt.Count++;
                        }
                        else
                        {
                            response.OrderItems.Add(new Dtos.OrderItemDto
                            {
                                Name = detail.Name,
                                Price = detail.Price,
                                ProductCode = detail.ProductCode,
                                Count = 1
                            });
                        }
                    });

                    result.Add(response);
                }

                return result;
            }
        }
    }
}
