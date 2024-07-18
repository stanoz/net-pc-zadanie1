using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos.SubCategory;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

/// <summary>
/// Serwis do obsługi podkategorii.
/// Implementuje interfejs <c>ISubCategoryService</c>.
/// </summary>
public class SubCategoryService : ISubCategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Konstruktor serwisu podkategorii.
    /// </summary>
    /// <param name="dataContext">Obiekt klasy bazy danych.</param>
    /// <param name="mapper">Obiekt klasy automatycznego mappera.</param>
    public SubCategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Asynchroniczna metoda do pobierania wszystkich podkategorii.
    /// </summary>
    /// <returns>
    /// Zwraca listę podkategorii w postaci <c>ServiceResponse</c> zawierającego
    /// listę obiektów <c>SubCategoryDto</c>.
    /// </returns>
    public async Task<ServiceResponse<List<SubCategoryDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<SubCategoryDto>>();

        try
        {
            /// Pobieranie podkategorii z bazy danych.
            var dbSubCategories = await _dataContext.SubCategories.ToListAsync();

            /// Mapowanie danych na obiekty DTO.
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