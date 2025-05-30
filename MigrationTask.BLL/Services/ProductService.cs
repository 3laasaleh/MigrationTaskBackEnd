using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Interfaces;
using MigrationTask.DAL.IRepositories;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Migration_Task.Data.Entities;
using MigrationTask.BLL.Extensions;

namespace MigrationTask.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<IProductRepository> _logger;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<IProductRepository> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task AddProductAsync(ProductDto product)
        {
            try
            {

                await _productRepository.AddProductAsync(_mapper.Map<Product>(product));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "AddProductAsync");
                throw;
            }
        }
        public async Task UpdateProductAsync(ProductDto product)
        {
            try
            {
                var entity = await _productRepository.GetProductByIdAsync(product.ProductId);
                if (entity == null)
                    return;
                // Update the entity with the new values
                entity.ProductName = product.ProductName;
                entity.Price = product.Price;
                entity.StockQuantity = product.StockQuantity;
                entity.CategoryId = product.CategoryId;
                entity.Status = product.Status.GetBoolValue();

                await _productRepository.UpdateProductAsync(entity);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "UpdateProductAsync");
                throw;
            }
        }
        public async Task DeleteProductAsync(int Id)
        {
            try
            {
                var entity = await _productRepository.GetProductByIdAsync(Id);
                if (entity == null)
                    return;
                await _productRepository.DeleteProductAsync(entity);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "DeleteProductAsync");
                throw;
            }
        }

        public async Task<ProductDto?> GetProductByIdAsync(int Id)
        {

            try
            {

                var data = await _productRepository.GetProductByIdAsync(Id);
                return _mapper.Map<ProductDto>(data);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "GetProductByIdAsync");
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            try
            {
                var data = await _productRepository.GetProductsAsync();
                return _mapper.Map<IEnumerable<ProductDto>>(data);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "GetAllProductsAsync");
                throw;
            }
        }


    }
}
