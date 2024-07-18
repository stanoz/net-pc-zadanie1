using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

/// <summary>
/// Serwis do obsługi kategorii.
/// Implementuje interfejs <c>ICategoryService</c>.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Konstruktor serwisu kategorii.
    /// </summary>
    /// <param name="dataContext">Obiekt klasy bazy danych.</param>
    /// <param name="mapper">Obiekt klasy automatycznego mappera.</param>
    public CategoryService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Asynchroniczna metoda do pobierania wszystkich kategorii.
    /// </summary>
    /// <returns>
    /// Zwraca listę kategorii w postaci obiektu <c>ServiceResponse</c>.
    /// </returns>
    /// <exception>
    /// Wyjątek w przypadku błędu podczas interakcji z bazą danych.
    /// </exception>
    public async Task<ServiceResponse<List<GetCategoryDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

        try
        {
            /// Pobieranie kategorii z bazy danych.
            var dbCategories = await _dataContext.Categories.ToListAsync();

            /// Mapowanie kategorii na obiekty DTO.
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