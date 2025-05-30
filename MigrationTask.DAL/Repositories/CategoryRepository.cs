

using Microsoft.EntityFrameworkCore;
using Migration_Task.Data;
using Migration_Task.Data.Entities;
using MigrationTask.DAL.IRepositories;

namespace MigrationTask.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MigrationTaskContext _db;
        public CategoryRepository(MigrationTaskContext context)
        {
            _db = context;
        }
        public async  Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }
    }
}
