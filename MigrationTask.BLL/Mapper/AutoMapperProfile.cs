using AutoMapper;
using Migration_Task.Data.Entities;
using MigrationTask.BLL.Dtos;
using MigrationTask.BLL.Extensions;


namespace MigrationTask.BLL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                //.ForMember(s=>s.Status,d=>d.MapFrom(p=>p.Status))
                .ForMember(s=>s.StatusDesc,d=>d.MapFrom(p=>p.Status.GetName()))
                .ForMember(s=>s.Description,d=>d.MapFrom(p=>p.ProductDescription))
                .ForMember(s=>s.CategoryName,d=>d.MapFrom(p=>p.Category==null?"": p.Category.CategoryName))
                .ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
