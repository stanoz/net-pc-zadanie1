using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public CategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCategoryDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

        try
        {
            var dbCategories = await _dataContext.Categories.ToListAsync();

            serviceResponse.Data = dbCategories.Select(category => _mapper.Map<GetCategoryDto>(category)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}