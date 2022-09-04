namespace PersistenceLayer.Repositories.ProductDetails
{
	using CodeLists.Exceptions;
	using DomainLayer.Entities.Product;
	using global::Extensions;
	using Microsoft.EntityFrameworkCore;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;
	using PersistenceLayer.Exceptions;
	using X.PagedList;

	public class ProductDetailsRepository : IProductDetailsRepository
	{
		private readonly IDbContext _dbContext;

		public ProductDetailsRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<ProductDetailEntity> UpdateProductDetailDescriptionAsync(int productId, string newDescription, CancellationToken ct)
		{
			var entity = await _dbContext.ProductDetails
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.Id == productId, ct);

			if (entity is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product detail not found");
			}

			if (entity.Description == newDescription)
			{
				throw new PersistanceLayerException(ExceptionType.NotModified, "Product detail is already up to date");
			}

			try
			{
				entity.Description = newDescription;

				_dbContext.ProductDetails.Update(entity);
				await _dbContext.SaveChangesAsync(ct);
			}
			catch (Exception ex)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "Error while updating product detail", ex);
			}

			return entity;
		}

		/// <inheritdoc/>
		public async Task<ProductDetailEntity> GetProductDetailByProductCode(string productCode, CancellationToken ct)
		{
			var productDetail = await _dbContext.ProductDetails
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.ProductCode == productCode, ct);

			if (productDetail is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product detail not found");
			}

			return productDetail;
		}

		/// <inheritdoc/>
		public async Task<List<ProductDetailEntity>> GetProductDetailsPaginatedAsync(int pageNumber, int pageSize, Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct)
		{
			var products = await _dbContext.ProductDetails
					.AsNoTracking()
					.IfThenElse(
						() => orderByDesc,
						e => e.OrderByDescending(orderBy),
						e => e.OrderBy(orderBy))
					.ToPagedListAsync(pageNumber, pageSize, ct);

			if (products.Count == 0)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product details not found");
			}

			return products.ToList();
		}

		/// <inheritdoc/>
		public async Task<List<ProductDetailEntity>> GetProductDetailsAsync(Func<ProductDetailEntity, object> orderBy, bool orderByDesc, CancellationToken ct)
		{
			var products = await _dbContext.ProductDetails
					.AsNoTracking()
					.ToListAsync(ct);

			products = products.IfThenElse(
					() => orderByDesc,
					e => e.OrderByDescending(orderBy),
					e => e.OrderBy(orderBy))
				.ToList();

			if (products.Count == 0)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product details not found");
			}

			return products;
		}
	}
}
