namespace PersistanceLayer.Contracts.Repositories
{
	using DomainLayer.Entities.Product;

	public interface IProductCategoriesRepository
	{
		/// <summary>
		/// Get product categories
		/// </summary>
		/// <param name="ct">cancellation token</param>
		/// <returns>product categories</returns>
		Task<List<ProductCategoryEntity>> GetProductCategoriesAsync(CancellationToken ct);

		/// <summary>
		/// Get product categories by id
		/// </summary>
		/// <param name="id">category id</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task<List<ProductCategoryEntity>> GetProductCategoriesByIdAsync(int id, CancellationToken ct);
	}
}
