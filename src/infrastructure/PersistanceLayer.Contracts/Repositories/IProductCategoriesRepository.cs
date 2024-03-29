﻿using DomainLayer.Entities.Product;

namespace PersistanceLayer.Contracts.Repositories
{
	public interface IProductCategoriesRepository
	{
		/// <summary>
		/// Get product categories by id
		/// </summary>
		/// <param name="id">category id</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task<List<ProductCategoryEntity>> GetProductCategoriesByIdAsync(int id, CancellationToken ct);
	}
}
