namespace PersistenceLayer.Repositories
{
    using ApplicationLayer.Interfaces;
    using Database.Extensions.LINQ;
    using DomainLayer.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
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
    }
}
