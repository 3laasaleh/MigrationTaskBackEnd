using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Interfaces;

namespace MigrationTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IGenericResponse<IEnumerable<CategoryDto>>> Get()
        {

            return await _service.GetAllCategoriesAsync();

        }
    }
}
