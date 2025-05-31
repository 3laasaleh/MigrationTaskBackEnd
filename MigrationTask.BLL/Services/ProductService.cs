using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Interfaces;
using MigrationTask.DAL.IRepositories;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Migration_Task.Data.Entities;
using Migration_Task.Data.Enums;

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
            _mapper = mapper;
        }

        public async Task<IGenericResponse<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            try
            {
                var data = await _productRepository.GetProductsAsync();
                var res = _mapper.Map<IEnumerable<ProductDto>>(data);
                return new GenericResponse<IEnumerable<ProductDto>>(res);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "GetAllProductsAsync");
                throw;
            }
        }
        public async Task<IGenericResponse<ProductDto?>> AddProductAsync(ProductDto product)
        {
            try
            {
               var res =await _productRepository.AddProductAsync(_mapper.Map<Product>(product));
                if (res == null)
                    return new GenericResponse<ProductDto?>("Failed to add product");

                return new GenericResponse<ProductDto?>(_mapper.Map<ProductDto>(res), "Product added successfully");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "AddProductAsync");
                throw;
            }
        }
        public async  Task<IGenericResponse<ProductDto?>> UpdateProductAsync(ProductDto product)
        {
            try
            {
                var entity = await _productRepository.GetProductByIdAsync(product.ProductId);
                if (entity == null)
                    return new GenericResponse<ProductDto?>("ProductId is not found");

                if (entity.Status == ProductStatusEnum.Active)
                    return new GenericResponse<ProductDto?>("can not Update an active product");
                // Update the entity with the new values
                entity.ProductName = product.ProductName;
                entity.ProductDescription = product.Description;
                entity.Price = product.Price;
                entity.StockQuantity = product.StockQuantity;
                entity.CategoryId = product.CategoryId;
                entity.Status = product.Status;

                var res=  await _productRepository.UpdateProductAsync(entity);

                if (res == null)
                    return new GenericResponse<ProductDto?>("Failed to add product");

                return new GenericResponse<ProductDto?>(_mapper.Map<ProductDto>(res), "Product added successfully");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "UpdateProductAsync");
                throw;
            }
        }
        public async Task<IGenericResponse<bool>> DeleteProductAsync(int Id)
        {
            try
            {
                var entity = await _productRepository.GetProductByIdAsync(Id);
                if (entity == null)
                    return new GenericResponse<bool>("Id not found");
                if (entity.Status==ProductStatusEnum.Active)
                    return new GenericResponse<bool>("can not delete an active product");
                var res=  await _productRepository.DeleteProductAsync(entity);
                if(res)
                    return new GenericResponse<bool>("Failed to Delete Product");

                return new GenericResponse<bool>(res,"product deleted successfully");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "DeleteProductAsync");
                throw;
            }
        }

        public async Task<IGenericResponse<ProductDto?>> GetProductByIdAsync(int Id)
        {

            try
            {

                var data = await _productRepository.GetProductByIdAsync(Id);
                if (data == null)
                    return new GenericResponse<ProductDto?>("Id not found");
                return new GenericResponse<ProductDto?>(_mapper.Map<ProductDto>(data));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "GetProductByIdAsync");
                throw;
            }
        }

   
    }
}
