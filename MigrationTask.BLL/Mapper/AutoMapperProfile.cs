using AutoMapper;
using Migration_Task.Data.Entities;
using MigrationTask.BLL.Dtos;


namespace MigrationTask.BLL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
