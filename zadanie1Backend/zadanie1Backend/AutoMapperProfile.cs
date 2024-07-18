using AutoMapper;
using zadanie1Backend.Dtos;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;

namespace zadanie1Backend;

/// <summary>
/// Klasa konfigurująca mapowania dla AutoMappera
/// Dziedziczy po klasie <c>Profile</c>.
/// </summary>
public class AutoMapperProfile : Profile
{
    /// <summary>
    /// Konstruktor klasy <c>AutoMapperProfile</c>, w którym
    /// zdefiniowane są wszystkie konfiguracje mapowań.
    /// </summary>
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