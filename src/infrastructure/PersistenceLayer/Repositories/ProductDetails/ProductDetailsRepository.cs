using CodeLists.Exceptions;
using DomainLayer.Entities.Product;
using Extensions;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Repositories;
using PersistenceLayer.Exceptions;
using X.PagedList;

namespace PersistenceLayer.Repositories.ProductDetails
{
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
					.Include(i => i.Products)
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
					.Include(i => i.Products)
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
					.Include(i => i.Products)
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

		/// <inheritdoc/>
		public async Task<List<ProductDetailEntity>> SearchProductDetailAsync(string phrase, int pageNumber, int pageSize, CancellationToken ct)
		{
			var products = await _dbContext.ProductDetails
				.AsNoTracking()
				.Include(i => i.Products)
				.Where(p => p.Name.Contains(phrase))
				.ToPagedListAsync(pageNumber, pageSize, ct);

			if (products.Count == 0)
			{
				var productsWOdiacritics = await _dbContext.ProductDetails
					.AsNoTracking()
					.ToListAsync();

				productsWOdiacritics.ForEach(p => p.Name = p.Name.RemoveDiacritics());

				var prodsIds = productsWOdiacritics
					.Where(p => p.Name.Contains(phrase.RemoveDiacritics()))
					.Select(x => x.Id)
					.ToPagedList(pageNumber, pageSize);

				products = await _dbContext.ProductDetails
					.AsNoTracking()
					.Where(p => prodsIds.Contains(p.Id))
					.ToPagedListAsync(pageNumber, pageSize, ct);

				if (products.Count == 0)
				{
					throw new PersistanceLayerException(ExceptionType.NotFound, "Product details not found");
				}
			}

			return products.ToList();
		}

		public async Task<List<ProductDetailEntity>> GetProductDetailByCategoryAsync(int catId, int pageNumber, int pageSize, CancellationToken ct)
		{
			var products = (await _dbContext.ProductDetails
					.AsNoTracking()
					.Include(i => i.Products)
					.Where(p => p.ProductCategoryId == catId)
					.ToPagedListAsync(pageNumber, pageSize, ct))
					.ToList();

			return products;
		}
	}
}
