namespace PersistenceLayer.Repositories
{
    using ApplicationLayer.Interfaces;
    using Database.Extensions.LINQ;
    using DomainLayer.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using X.PagedList;

    public class GenericRepository<T> : IGenericRepository<T> where T : AuditableEntity
    {
        private readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext) => _dbContext = dbContext;

        /// <inheritdoc/>
        public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<T>> GetAllAsync(bool orderByDesc, Func<T, object> orderBy, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>()
                    .IfThenElse(
                        () => orderByDesc,
                        e => e.OrderByDescending(orderBy),
                        e => e.OrderBy(orderBy))
                    .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<T>> GetAllPaginatedAsync(int pageNum, int pageSize, bool orderByDesc, Func<T, object> orderBy, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>()
                    .IfThenElse(
                        () => orderByDesc,
                        e => e.OrderByDescending(orderBy),
                        e => e.OrderBy(orderBy))
                    .ToPagedListAsync(pageNum, pageSize, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<T>> GetAllWhereAsync(Func<T, bool> whereClause, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>()
                .Where(whereClause)
                .ToListAsync(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<IReadOnlyList<T2>> SelectAsync<T2>(Func<T, T2> selectClause, CancellationToken cancellationToken) where T2 : class
        {
            return await _dbContext.Set<T>()
                .Select(selectClause)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> clause, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(clause, cancellationToken);
        }

        /// <inheritdoc/>
        public IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            return _dbContext.Set<T>().Include(navigationPropertyPath);
        }
    }
}
