using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using zadanie1Backend.Data;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public class ContactService : IContactService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ContactService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetContactDto>>> GetAllContacts()
    {
        var serviceResponse = new ServiceResponse<List<GetContactDto>>();
        try
        {
            var dbContacts = await _dataContext.Contacts
                .Include(c => c.Category)
                .ToListAsync();

            serviceResponse.Data = dbContacts
                .Select(contact => _mapper.Map<GetContactDto>(contact))
                .ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetContactDto>> GetContactById(int id)
    {
        var serviceResponse = new ServiceResponse<GetContactDto>();
        try
        {
            var dbContact = await _dataContext.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetContactDto>(dbContact);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public Task<ServiceResponse<GetContactDto>> EditContact(int id, PutContactDto putContactDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetContactDto>> AddContact(PostContactDto postContactDto)
    {
        throw new NotImplementedException();
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