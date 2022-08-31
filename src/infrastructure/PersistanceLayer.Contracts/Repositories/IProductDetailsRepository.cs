using DomainLayer.Entities.Product;

namespace PersistanceLayer.Contracts.Repositories
{
	public interface IProductDetailsRepository
	{
		/// <summary>
		/// Update product detail description
		/// </summary>
		/// <param name="productId">product id</param>
		/// <param name="newDescription">new description</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>Detail of updated</returns>
		Task<ProductDetailEntity> UpdateProductDetailDescriptionAsync(int productId, string newDescription, CancellationToken ct);

		/// <summary>
		/// Get product detail by product code
		/// </summary>
		/// <param name="productCode">product code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>Product detai</returns>
		Task<ProductDetailEntity> GetProductDetailByProductCode(string productCode, CancellationToken ct);

		/// <summary>
		/// Get pagianted product details
		/// </summary>
		/// <param name="pageNumber">page number</param>
		/// <param name="pageSize">page size</param>
		/// <param name="orderBy">orderby</param>
		/// <param name="orderByDesc">orderby descending</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>paged list of product details</returns>
		Task<List<ProductDetailEntity>> GetProductDetailsPaginatedAsync(int pageNumber, int pageSize, Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct);

		/// <summary>
		/// Get product details
		/// </summary>
		/// <param name="orderBy">orderby</param>
		/// <param name="orderByDesc">orderby descending</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>list of product details</returns>
		Task<List<ProductDetailEntity>> GetProductDetailsAsync(Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct);
	}
}
