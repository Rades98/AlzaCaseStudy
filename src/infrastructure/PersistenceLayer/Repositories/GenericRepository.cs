namespace PersistenceLayer.Repositories
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities;
    using Microsoft.EntityFrameworkCore;
    using PersistenceLayer.Database.Extensions.LINQ;
    using System.Linq;
    using System.Threading.Tasks;
    using X.PagedList;

    public class GenericRepository<T> : IGenericRepository<T> where T : AuditableEntity
    {
        private readonly IDbContext _dbContext;

        public GenericRepository(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<T?> Get(Guid id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAll(bool orderByDesc, Func<T, object> orderBy)
        {
            return await _dbContext.Set<T>()
                    .IfThenElse(
                        () => orderByDesc,
                        e => e.OrderByDescending(orderBy),
                        e => e.OrderBy(orderBy))
                    .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllPaginated(int pageNum, int pageSize, bool orderByDesc, Func<T, object> orderBy)
        {
            return await _dbContext.Set<T>()
                    .IfThenElse(
                        () => orderByDesc,
                        e => e.OrderByDescending(orderBy),
                        e => e.OrderBy(orderBy))
                    .ToPagedListAsync(pageNum, pageSize);

        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
}
