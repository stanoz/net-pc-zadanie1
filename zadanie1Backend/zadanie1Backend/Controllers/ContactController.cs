using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetAll()
    {
        return Ok(await _contactService.GetAllContacts());
    }

    [HttpGet("get-contact-{email}")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> GetContactById(string email)
    {
        return Ok(await _contactService.GetContactByEmail(email));
    }

    [HttpPost("add-contact")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> AddContact([FromBody] PostAndPutContactDto postContactDto)
    {
        return Ok(await _contactService.AddContact(postContactDto));
    }

    [HttpPut("edit-contact-{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> EditContact(int id,
        [FromBody] PostAndPutContactDto putContactDto)
    {
        return Ok(await _contactService.EditContact(id, putContactDto));
    }

    [HttpDelete("delete-contact-{id:int}")]
    public async Task<ActionResult<ServiceResponse<int>>> DeleteContact(int id)
    {
        return Ok(await _contactService.DeleteContactById(id));
    }
}