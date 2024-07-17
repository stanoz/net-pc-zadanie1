using AutoMapper;
using zadanie1Backend.Dtos;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;

namespace zadanie1Backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<Contact, GetContactDto>();
        CreateMap<Category, GetCategoryDto>();
        CreateMap<Contact, GetGeneralContactDto>();
        CreateMap<SubCategory, SubCategoryDto>();
        CreateMap<PostAndPutCategoryDto, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<PostAndPutContactDto, Contact>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<SubCategoryDto, SubCategory>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}