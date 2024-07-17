using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<SubCategoryDto>>>> GetAll()
    {
        return Ok(await _subCategoryService.GetAll());
    }
}