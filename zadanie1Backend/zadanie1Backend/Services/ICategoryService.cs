using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

/// <summary>
/// Interfejs serwisu kategorii.
/// </summary>
public interface ICategoryService
{
    public Task<ServiceResponse<List<GetCategoryDto>>> GetAll();
}