using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public interface ICategoryService
{
    public Task<ServiceResponse<List<GetCategoryDto>>> GetAll();
}