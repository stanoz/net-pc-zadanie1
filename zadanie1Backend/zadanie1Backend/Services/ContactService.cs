using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Validator;

namespace zadanie1Backend.Services;

public class ContactService : IContactService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidate _validator;

    public ContactService(DataContext dataContext, IMapper mapper, IValidate validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ServiceResponse<List<GetGeneralContactDto>>> GetAllContacts()
    {
        var serviceResponse = new ServiceResponse<List<GetGeneralContactDto>>();
        try
        {
            var dbContacts = await _dataContext.Contacts
                // .Include(c => c.Category)
                .ToListAsync();

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

    public async Task<ServiceResponse<GetContactDto>> GetContactByEmail(string email)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Email == email);

            serviceResponse.Data = _mapper.Map<GetContactDto>(dbContact);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetContactDto>> EditContact(int id, PostAndPutContactDto putContactDto)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbContact is null)
            {
                throw new ArgumentException("Contact not found.");
            }

            if (!_validator.ValidateContact(putContactDto))
            {
                throw new ArgumentException("Contact data is not valid.");
            }

            dbContact.Name = putContactDto.Name;
            dbContact.Surname = putContactDto.Surname;
            dbContact.Email = putContactDto.Email;
            dbContact.PhoneNumber = putContactDto.PhoneNumber;
            dbContact.Birthday = putContactDto.Birthday;

            var category = await _dataContext.Categories
                .FirstOrDefaultAsync(c => c.Name == putContactDto.Category.Name);
            if (category == null)
            {
                category = _mapper.Map<Category>(putContactDto.Category);
                _dataContext.Categories.Add(category);
            }
            dbContact.Category = category;

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

    public async Task<ServiceResponse<GetContactDto>> AddContact(PostAndPutContactDto postContactDto)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Email == postContactDto.Email);
            if (dbContact is not null)
            {
                throw new ArgumentException("Contact with given email address already exists!");
            }

            if (!_validator.ValidateContact(postContactDto))
            {
                throw new ArgumentException("Contact data is not valid!");
            }

            var category = await _dataContext.Categories
                .FirstOrDefaultAsync(c => c.Name == postContactDto.Category.Name);

            if (category == null)
            {
                category = _mapper.Map<Category>(postContactDto.Category);
                _dataContext.Categories.Add(category);
            }

            var contact = _mapper.Map<Contact>(postContactDto);
            contact.Category = category;

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

    public async Task<ServiceResponse<int>> DeleteContactById(int id)
    {
        var serviceResponse = new ServiceResponse<int>();
        try
        {
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbContact is null)
            {
                throw new ArgumentException("Contact not found.");
            }

            _dataContext.Contacts.Remove(dbContact);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = id;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}