using zadanie1Backend.Dtos;
using zadanie1Backend.Models;

namespace zadanie1Backend.Services;

public interface IContactService
{
    public Task<ServiceResponse<List<GetGeneralContactDto>>> GetAllContacts();
    public Task<ServiceResponse<GetContactDto>> GetContactByEmail(string email);
    public Task<ServiceResponse<GetContactDto>> EditContact(int id, PostAndPutContactDto putContactDto);
    public Task<ServiceResponse<GetContactDto>> AddContact(PostAndPutContactDto postContactDto);
    public Task<ServiceResponse<string>> DeleteContactByEmail(string email);
}