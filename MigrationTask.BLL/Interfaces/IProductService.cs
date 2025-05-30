using MigrationTask.BLL.Dtos;

namespace MigrationTask.BLL.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto?> GetProductByIdAsync(int Id);
        public Task AddProductAsync(ProductDto product);
        public Task UpdateProductAsync(ProductDto product);
        public Task DeleteProductAsync(int Id);
    }
}
