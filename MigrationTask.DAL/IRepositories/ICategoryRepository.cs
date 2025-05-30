

using Migration_Task.Data.Entities;

namespace MigrationTask.DAL.IRepositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
