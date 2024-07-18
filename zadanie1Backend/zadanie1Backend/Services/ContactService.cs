using AutoMapper;
using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Validator;

namespace zadanie1Backend.Services;

/// <summary>
/// Serwis do obsługi operacji na kontaktach.
/// Implementuje  interfejs <c>IContactService</c>.
/// </summary>
public class ContactService : IContactService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidate _validator;

    /// <summary>
    /// Konstruktor serwisu.
    /// </summary>
    /// <param name="dataContext">Obiekt bazy danych.</param>
    /// <param name="mapper">Obiekt automatycznego mappera.</param>
    /// <param name="validator">Obiekt validatora.</param>
    public ContactService(DataContext dataContext, IMapper mapper, IValidate validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }

    /// <summary>
    /// Asynchroniczna metoda zwraca wszystkie kontakty z bazy danych.
    /// </summary>
    /// <exception>
    /// Wyjątek w przypadku błędu podczas pobierania danych z bazy danych lub mapowania.
    /// </exception>
    /// <returns>
    /// Zwraca listę kontaktów w postaci <c>ServiceResponse</c> zawierającego listę obiektów <c>GetGeneralContactDto</c>
    /// </returns>
    public async Task<ServiceResponse<List<GetGeneralContactDto>>> GetAllContacts()
    {
        var serviceResponse = new ServiceResponse<List<GetGeneralContactDto>>();
        try
        {
            /// Pobieranie kontaktów z bazy danych wraz z kategoriami.
            var dbContacts = await _dataContext.Contacts
                .Include(c => c.Category)
                .ToListAsync();

            /// Mapowanie danych z bazy danych na obiekty DTO.
            serviceResponse.Data = dbContacts
                .Select(contact => _mapper.Map<GetGeneralContactDto>(contact))
                .ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    /// <summary>
    /// Asynchroniczna metoda zwraca kontakt o podanym adresie email z bazy danych.
    /// </summary>
    /// <param name="email">Adres email kontatku jako <c>string</c>.</param>
    /// <exception>
    /// Wyjątek w przypadku błędu podczas pobierania danych z bazy danych lub mapowania.
    /// </exception>
    /// <returns>
    /// Zwraca obiekt <c>ServiceResponse</c> zawierający kontatk jako obiekt <c>GetContactDto</c>.
    /// </returns>
    public async Task<ServiceResponse<GetContactDto>> GetContactByEmail(string email)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            /// Pobiera kontakt z bazy danych wraz z kategorią i podkategorią.
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .FirstOrDefaultAsync(c => c.Email == email);

            /// Mapowanie danych z bazy danych na obiekt DTO.
            serviceResponse.Data = _mapper.Map<GetContactDto>(dbContact);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    /// <summary>
    /// Asynchroniczna metoda edytuje kontakt o podanym adresie email.
    /// </summary>
    /// <param name="email">Adres email kontatku jako <c>string</c>.</param>
    /// <param name="putContactDto">Obiekt klasy <c>PostAndPutContactDto</c>
    /// Zawiera zmienione dane kontaktu.</param>
    /// <returns>
    /// Zwraca obiekt <c>ServiceResponse</c> zawierający edytowany kontakt jako obiekt <c>GetContactDto</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Wyjątek w przypadku gdy kontakt nie został znaleziony w bazie danych.
    /// Wyjątek w przypadku gdy dane kontaktu są niepoprawne.
    /// </exception>
    /// <exception>
    /// Wyjątek w przypadku niepowodzenia mapowania danych.
    /// Wyjątek w przypadku błędu podczas interakcji z bazą danych.
    /// </exception>
    public async Task<ServiceResponse<GetContactDto>> EditContact(string email, PostAndPutContactDto putContactDto)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            /// Pobieranie kontaktu z bazy danych wraz z kategorią i podkategorią.
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .FirstOrDefaultAsync(c => c.Email == email);
            if (dbContact is null)
            {
                throw new ArgumentException("Contact not found.");
            }

            if (!_validator.ValidateContact(putContactDto))
            {
                throw new ArgumentException("Contact data is not valid.");
            }

            /// Mapowanie danych z obiektu DTO na obiekt bazy danych.
            dbContact.Name = putContactDto.Name;
            dbContact.Surname = putContactDto.Surname;
            dbContact.Email = putContactDto.Email;
            dbContact.Password = BCrypt.Net.BCrypt.HashPassword(putContactDto.Password);
            dbContact.PhoneNumber = putContactDto.PhoneNumber;
            dbContact.Birthday = putContactDto.Birthday;

            /// Sprawdzenie czy kategoria istnieje w bazie danych.
            var category = await _dataContext.Categories
                .FirstOrDefaultAsync(c => c.Name == putContactDto.Category.Name);
            if (category is null)
            {
                /// Dodanie nowej kategorii do bazy danych.
                category = _mapper.Map<Category>(putContactDto.Category);
                _dataContext.Categories.Add(category);
            }

            dbContact.Category = category;

            /// Sprawdzenie czy podkategoria istnieje w bazie danych.
            if (putContactDto.SubCategory != null && !string.IsNullOrWhiteSpace(putContactDto.SubCategory.Name))
            {
                var subCategory = await _dataContext.SubCategories
                    .FirstOrDefaultAsync(sc => sc.Name == putContactDto.SubCategory.Name);
                if (subCategory is null)
                {
                    /// Dodanie nowej podkategorii do bazy danych.
                    subCategory = _mapper.Map<SubCategory>(putContactDto.SubCategory);
                    _dataContext.SubCategories.Add(subCategory);
                }

                dbContact.SubCategory = subCategory;
            }
            else
            {
                /// Usunięcie podkategorii z kontaktu.
                dbContact.SubCategory = null;
            }

            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetContactDto>(dbContact);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    /// <summary>
    /// Asynchroniczna metoda dodaje nowy kontakt do bazy danych.
    /// </summary>
    /// <param name="postContactDto">Obiekt klasy <c>PostAndPutContactDto</c>
    /// zawiera dane do nowego kontaktu.</param>
    /// <returns>
    /// Zwraca obiekt <c>ServiceResponse</c> zawierający dodany kontakt jako obiekt klasy <c>GetContactDto</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Wyjątek w przypadku gdy kontakt o podanym adresie email już istnieje w bazie danych.
    /// Wyjątek w przypadku gdy dane kontaktu są niepoprawne.
    /// </exception>
    /// <exception>
    /// Wyjątek w przypadku niepowodzenia mapowania danych.
    /// Wyjątek w przypadku błędu podczas interakcji z bazą danych.
    /// </exception>
    public async Task<ServiceResponse<GetContactDto>> AddContact(PostAndPutContactDto postContactDto)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            /// Pobieranie kontaktu z bazy danych wraz z kategorią.
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Email == postContactDto.Email);
            /// Sprawdzenie czy kontakt o podanym adresie email już istnieje w bazie danych.
            if (dbContact is not null)
            {
                throw new ArgumentException("Contact with given email address already exists!");
            }

            if (!_validator.ValidateContact(postContactDto))
            {
                throw new ArgumentException("Contact data is not valid!");
            }

            /// Sprawdzenie czy kategoria istnieje w bazie danych.
            var category = await _dataContext.Categories
                .FirstOrDefaultAsync(c => c.Name == postContactDto.Category.Name);

            /// Dodanie nowej kategorii do bazy danych.
            if (category is null)
            {
                category = _mapper.Map<Category>(postContactDto.Category);
                _dataContext.Categories.Add(category);
            }

            /// Sprawdzanie czy podkategoria została dodana.
            SubCategory subCategory = null;
            if (postContactDto.SubCategory != null && !string.IsNullOrWhiteSpace(postContactDto.SubCategory.Name))
            {
                /// Sprawdzenie czy podkategoria istnieje w bazie danych.
                subCategory = await _dataContext.SubCategories
                    .FirstOrDefaultAsync(sc => sc.Name == postContactDto.SubCategory.Name);

                /// Dodanie nowej podkategorii do bazy danych.
                if (subCategory is null)
                {
                    subCategory = _mapper.Map<SubCategory>(postContactDto.SubCategory);
                    _dataContext.SubCategories.Add(subCategory);
                }
            }

            var contact = _mapper.Map<Contact>(postContactDto);
            contact.Category = category;
            contact.SubCategory = subCategory;

            contact.Password = BCrypt.Net.BCrypt.HashPassword(contact.Password);

            _dataContext.Contacts.Add(contact);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetContactDto>(contact);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    /// <summary>
    /// Asynchroniczna metoda usuwa kontakt o podanym adresie email z bazy danych.
    /// </summary>
    /// <param name="email">Adres email kontatku jako <c>string</c>.</param>
    /// <returns>
    /// Zwaca obiekt <c>ServiceResponse</c> zawierający adres email usuniętego kontaktu jako <c>string</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Wyjątek w przypadku gdy kontakt nie został znaleziony w bazie danych.
    /// </exception>
    /// <exception>
    /// Wyjątek w przypadku błędu podczas interakcji z bazą danych.
    /// </exception>
    public async Task<ServiceResponse<string>> DeleteContactByEmail(string email)
    {
        var serviceResponse = new ServiceResponse<string>();
        try
        {
            /// Sprawdzenie czy kontakt o podanym adresie email istnieje w bazie danych.
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .FirstOrDefaultAsync(c => c.Email == email);
            if (dbContact is null)
            {
                throw new ArgumentException("Contact not found.");
            }

            _dataContext.Contacts.Remove(dbContact);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = email;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}