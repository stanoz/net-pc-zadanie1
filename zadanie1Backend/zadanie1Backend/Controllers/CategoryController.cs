using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

/// <summary>
/// Kontroler dla encji <c>Category</c>.
/// Dziedziczy po <c>ControllerBase</c>.
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Konstruktor klasy <c>CategoryController</c>.
    /// </summary>
    /// <param name="categoryService">Obiekt <c>ICategoryService</c> będący serwisem dla kategorii.</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Endpoint typu GET zwracający wszystkie kategorie.
    /// </summary>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// listę obiektów typu <c>GetCategoryDto</c>.
    /// </returns>
    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> GetAll()
    {
        return Ok(await _categoryService.GetAll());
    }
}