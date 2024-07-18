using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

/// <summary>
/// Kontroler dla encji <c>SubCategory</c>.
/// Dziedziczy po <c>ControllerBase</c>.
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    /// <summary>
    /// Konstruktor klasy <c>SubCategoryController</c>.
    /// </summary>
    /// <param name="subCategoryService">Obiekt <c>ISubCategoryService</c> będący serwisem dla podkategorii.</param>
    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    /// <summary>
    /// Endpoint typu GET zwracający wszystkie podkategorie.
    /// </summary>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// listę obiektów typu <c>SubCategoryDto</c>.
    /// </returns>

    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<SubCategoryDto>>>> GetAll()
    {
        return Ok(await _subCategoryService.GetAll());
    }
}