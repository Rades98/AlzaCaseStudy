namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	using ApplicationLayer.Requests.ProductDetails.Queries;
	using DomainLayer.Entities.Product;
	using Exceptions;
	using Extensions;
	using Interfaces;
	using Interfaces.Cache;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using Queries;

	/// <summary>
	/// Query to obtain all products
	/// </summary>
	/// <returns>
	///  List of products or null, if there are none
	/// </returns>
	public class ProductDetailsGetRequest : IRequest<IEnumerable<ProductDetailGetResponse>>, ICacheableQuery
	{
		public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
		public bool OrderByDesc { get; set; } = false;
		public string CacheKey => Cache.CacheKeys.ProductDetails;

		public class Handler : IRequestHandler<ProductDetailsGetRequest, IEnumerable<ProductDetailGetResponse>>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<IEnumerable<ProductDetailGetResponse>> Handle(ProductDetailsGetRequest request, CancellationToken cancellationToken)
			{
				var products = await _dbContext.ProductDetails
					.AsNoTracking()
					.ToListAsync(cancellationToken);

				products = products.IfThenElse(
						() => request.OrderByDesc,
						e => e.OrderByDescending(request.OrderBy),
						e => e.OrderBy(request.OrderBy))
					.ToList();

				if (products.Count > 0)
				{
					return products.Select(x => (ProductDetailGetResponse)x);
				}

				throw new CRUDException(ExceptionTypeEnum.NotFound, "Product details not found");
			}
		}
	}
}
