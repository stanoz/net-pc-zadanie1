using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

/// <summary>
/// Interfejs serwisu podkategorii.
/// </summary>
public interface ISubCategoryService
{
    public Task<ServiceResponse<List<SubCategoryDto>>> GetAll();
}