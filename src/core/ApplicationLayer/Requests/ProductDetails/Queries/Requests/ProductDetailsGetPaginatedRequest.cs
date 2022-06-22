namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductDetails.Queries;
	using DomainLayer.Entities.Product;
	using Extensions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using X.PagedList;

	/// <summary>
	/// Query to obtain all products wit pagination settings
	/// </summary>
	/// <returns>
	/// Paged list of products, if not found then null
	/// </returns>
	public class ProductDetailsGetPaginatedRequest : IRequest<IEnumerable<ProductDetailGetResponse>>
	{
		public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
		public bool OrderByDesc { get; set; } = false;

		public int PageNumber { get; set; } = 1;

		public int PageSize { get; set; } = 10;

		public class Handler : IRequestHandler<ProductDetailsGetPaginatedRequest, IEnumerable<ProductDetailGetResponse>>
		{
			private readonly IDbContext _dbContext;
			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<IEnumerable<ProductDetailGetResponse>> Handle(ProductDetailsGetPaginatedRequest request, CancellationToken cancellationToken)
			{
				var products = await _dbContext.ProductDetails
					.AsNoTracking()
					.IfThenElse(
						() => request.OrderByDesc,
						e => e.OrderByDescending(request.OrderBy),
						e => e.OrderBy(request.OrderBy))
					.ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);

				if (products.Count > 0)
				{
					return products.Select(x => (ProductDetailGetResponse)x);
				}

				throw new CRUDException(ExceptionTypeEnum.NotFound, "Product details not found");
			}
		}
	}
}
