namespace ApplicationLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T?> Get(Guid id);

        public Task<IReadOnlyList<T>> GetAll(bool orderByDesc, Func<T, object> orderBy);

        public Task<IReadOnlyList<T>> GetAllPaginated(int pageNum, int pageSize, bool orderByDesc, Func<T, object> orderBy);

        public Task Update(T entity);
    }
}
