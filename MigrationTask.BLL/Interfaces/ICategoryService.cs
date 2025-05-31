using MigrationTask.BLL.Dtos;


namespace MigrationTask.BLL.Interfaces
{
    public interface ICategoryService
    {
        public Task<IGenericResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
    }
}
