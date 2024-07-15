using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public class ContactService : IContactService
{
    public Task<ServiceResponse<List<GetContactDto>>> GetAllContacts()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetContactDto>> GetContactById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetContactDto>> EditContact(int id, PutContactDto putContactDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetContactDto>> AddContact(PostContactDto postContactDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<int>> DeleteContactById(int id)
    {
        throw new NotImplementedException();
    }
}