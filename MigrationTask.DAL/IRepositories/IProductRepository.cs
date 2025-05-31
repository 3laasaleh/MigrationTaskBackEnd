

using Migration_Task.Data.Entities;

namespace MigrationTask.DAL.IRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product?> GetProductByIdAsync(int Id);
        public Task<Product?> AddProductAsync(Product product);
        public Task<Product?> UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(Product product);

    }
}
