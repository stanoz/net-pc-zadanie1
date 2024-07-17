using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> GetAll()
    {
        return Ok(await _categoryService.GetAll());
    }
}