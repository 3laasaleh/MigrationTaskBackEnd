using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Interfaces;

namespace MigrationTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IGenericResponse<IEnumerable<ProductDto>>> Get()
        {
           return await _productService.GetAllProductsAsync();
        }
        [HttpGet("{id}")]
        public async Task<IGenericResponse<ProductDto?>> GetProductById(int id)
        {
            return await _productService.GetProductByIdAsync(id);
       
        }
        [HttpDelete("{id}")]
        public async Task<IGenericResponse<bool>> Delete(int id)
        {
            return await _productService.DeleteProductAsync(id);

        }
        [HttpPost]
        public async Task<IGenericResponse<ProductDto?>> Post([FromBody] ProductDto productDto)
        {

            return await _productService.AddProductAsync(productDto);
        }
        [HttpPut]
        public async Task<IGenericResponse<ProductDto?>> Put([FromBody] ProductDto productDto)
        {
      
            return await _productService.UpdateProductAsync(productDto);
           
        }
    }
}
