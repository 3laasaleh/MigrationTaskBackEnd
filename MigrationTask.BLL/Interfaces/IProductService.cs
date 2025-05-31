using MigrationTask.BLL.Dtos;

namespace MigrationTask.BLL.Interfaces
{
    public interface IProductService
    {
         Task<IGenericResponse<IEnumerable<ProductDto>>> GetAllProductsAsync();
         Task<IGenericResponse<ProductDto?>> GetProductByIdAsync(int Id);
          Task<IGenericResponse<ProductDto?>>  AddProductAsync(ProductDto product);
         Task<IGenericResponse<ProductDto?>> UpdateProductAsync(ProductDto product);
         Task<IGenericResponse<bool>> DeleteProductAsync(int Id);
    }
}
