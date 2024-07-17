using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public class SubCategoryService : ISubCategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public SubCategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<SubCategoryDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<SubCategoryDto>>();

        try
        {
            var dbSubCategories = await _dataContext.SubCategories.ToListAsync();

            serviceResponse.Data = dbSubCategories.Select(sc => _mapper.Map<SubCategoryDto>(sc)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}