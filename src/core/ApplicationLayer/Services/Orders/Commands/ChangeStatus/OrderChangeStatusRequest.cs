namespace ApplicationLayer.Services.Orders.Commands.ChangeStatus
{
    using ApplicationLayer.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class OrderChangeStatusRequest : IRequest<OrderChangeStatusResponse>
    {
        public Guid UserId { get; set; }
        public string OrderCode { get; set; }
        public Guid StatusId { get; set; }

        public class Handler : IRequestHandler<OrderChangeStatusRequest, OrderChangeStatusResponse>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<OrderChangeStatusResponse> Handle(OrderChangeStatusRequest request, CancellationToken cancellationToken)
            {
                var actual = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderCode == request.OrderCode, cancellationToken);

                if (actual is null)
                {
                    return new() { Message = OrderChangeStatusCommandMessages.NotFound };
                }

                if (actual.UserId != request.UserId)
                {
                    return new() { Message = OrderChangeStatusCommandMessages.WrongUser };
                }

                actual.OrderStatusId = request.StatusId;

                try
                {
                    _dbContext.Orders.Update(actual);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    return new OrderChangeStatusResponse { Message = OrderChangeStatusCommandMessages.StatusChanged };
                }
                catch (Exception _)
                {
                    return new() { Message = OrderChangeStatusCommandMessages.Error };
                }
            }
        }
    }
}
