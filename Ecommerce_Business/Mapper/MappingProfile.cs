using AutoMapper;
using Ecommerce_DataAccess.Data;
using Ecommerce_Models;

namespace Ecommerce_Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}
