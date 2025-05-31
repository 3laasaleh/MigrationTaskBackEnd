

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
        public async Task<Product?> AddProductAsync(Product product)
        {
         var res=  await _db.Products.AddAsync(product);
             await _db.SaveChangesAsync();
            return res.Entity;

        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
        
                _db.Products.Remove(product);
              var res=  await _db.SaveChangesAsync();
            return res > 0 ?true:false;
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            return await _db.Products.Include(s=>s.Category).SingleOrDefaultAsync(s=>s.ProductId==Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.Include(s=>s.Category).AsNoTracking().ToListAsync();
            // to solve the issue of tracking changes, while update enties

        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
          var res=  await _db.SaveChangesAsync();
            return res > 0 ? product : null ;
        }
    }
}
