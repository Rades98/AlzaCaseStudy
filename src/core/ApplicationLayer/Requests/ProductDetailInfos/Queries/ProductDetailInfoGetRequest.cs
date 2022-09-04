using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.ProductDetailInfos.Queries
{
	public class ProductDetailInfoGetRequest : IRequest<ProductDetailInfoGetResponse>
	{
		public string Code { get; set; } = string.Empty;

		public class Handler : IRequestHandler<ProductDetailInfoGetRequest, ProductDetailInfoGetResponse>
		{
			private readonly IProductDetailInfosRepository _repository;
			private readonly IOrderItemsRepository _orderItemsRepo;
			private readonly IProductsRepository _productRepo;

			public Handler(IOrderItemsRepository orderItemsRepository, IProductDetailInfosRepository repository, IProductsRepository productRepo)
			{
				_orderItemsRepo = orderItemsRepository ?? throw new ArgumentNullException(nameof(orderItemsRepository));
				_repository = repository ?? throw new ArgumentNullException(nameof(repository));
				_productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
			}

			public async Task<ProductDetailInfoGetResponse> Handle(ProductDetailInfoGetRequest request, CancellationToken cancellationToken)
			{
				var productDetail = await _repository.GetProductDetailInofAsync(request.Code, cancellationToken);

				int productCount = await _productRepo.GetProductCountByCodeAsync(request.Code, cancellationToken);
				int reservedProductsCount = await _orderItemsRepo.GetCountOfItemsByIdAsync(request.Code, cancellationToken);

				var result = (ProductDetailInfoGetResponse)productDetail;
				result.Count = productCount - reservedProductsCount;

				return result;
			}
		}
	}
}
