

using Migration_Task.Data.Entities;

namespace MigrationTask.DAL.IRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<Product?> GetProductByIdAsync(int Id);
        public Task AddProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(Product product);

    }
}
