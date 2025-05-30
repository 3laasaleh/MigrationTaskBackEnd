

using Microsoft.EntityFrameworkCore;
using Migration_Task.Data;
using Migration_Task.Data.Entities;
using MigrationTask.DAL.IRepositories;

namespace MigrationTask.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MigrationTaskContext _db;
        public ProductRepository(MigrationTaskContext context)
        {
            _db = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteProductAsync(Product product)
        {
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            return await _db.Products.FindAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();

        }

        public async Task UpdateProductAsync(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
