using AutoMapper;
using Microsoft.Extensions.Logging;
using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Interfaces;
using MigrationTask.DAL.IRepositories;


namespace MigrationTask.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ILogger<ICategoryRepository> _logger;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper, ILogger<ICategoryRepository> logger)
        {
            _CategoryRepository = CategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IGenericResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            try
            {
                var data = await _CategoryRepository.GetCategoriesAsync();
                var res= _mapper.Map<IEnumerable<CategoryDto>>(data);
                return new GenericResponse<IEnumerable<CategoryDto>>(res);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "GetAllCategorysAsync");
                throw;
            }
        }

  
    }
}
