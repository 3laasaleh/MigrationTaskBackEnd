

namespace MigrationTask.DAL.IRepositories
{
    public interface IGenericRepository<T>
    {
        public Task<IList<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int Id);
        public Task UpdateAsync(T Entity);
        public Task DeleteAsync(T Entity);
        public Task<T> AddAsync(T Entity);


    }
}
