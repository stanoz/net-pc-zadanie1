using AutoMapper;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Contact, GetContactDto>();
        CreateMap<Category, GetCategoryDto>();
    }
}