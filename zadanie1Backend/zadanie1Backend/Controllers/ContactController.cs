using Microsoft.AspNetCore.Mvc;
using zadanie1Backend.Dtos;
using zadanie1Backend.Models;
using zadanie1Backend.Services;

namespace zadanie1Backend.Controllers;

/// <summary>
/// Kontroler dla encji <c>Contact</c>.
/// Dziedziczy po <c>ControllerBase</c>.
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    /// <summary>
    /// Konsktruktor klasy <c>ContactController</c>.
    /// </summary>
    /// <param name="contactService">Obiekt <c>IContactService</c> będący serwisem dla kontaktu.</param>
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    /// <summary>
    /// Endpoint typu GET zwracający wszystkie kontakty.
    /// </summary>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// listę obiektów typu <c>GetContactDto</c>.
    /// </returns>
    [HttpGet("get-all")]
    public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetAll()
    {
        return Ok(await _contactService.GetAllContacts());
    }

    /// <summary>
    /// Endpoint typu GET zwracający kontakt o podanym adresie email.
    /// </summary>
    /// <param name="email">Adres email typu <c>string</c> kontaktu.</param>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// obiekt typu <c>GetContactDto</c>.
    /// </returns>
    [HttpGet("get-contact-{email}")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> GetContactById(string email)
    {
        return Ok(await _contactService.GetContactByEmail(email));
    }

    /// <summary>
    /// Endpoint typu POST dodający nowy kontakt.
    /// </summary>
    /// <param name="postContactDto">Obiekt typu <c>PostAndPutContactDto</c> zawierający
    /// dane do nowego kontaktu.</param>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym nowy kontakt
    /// w postaci obiektu typu <c>GetContactDto</c>.
    /// </returns>
    [HttpPost("add-contact")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> AddContact([FromBody] PostAndPutContactDto postContactDto)
    {
        return Ok(await _contactService.AddContact(postContactDto));
    }

    /// <summary>
    /// Endpoint typu POST edytujący kontakt o podanym adresie email.
    /// Typ PUT został zmieniiony na POST, ponieważ formularz z frontendu przesyła używając POST.
    /// </summary>
    /// <param name="email">Adres email kontatku jako <c>string</c>.</param>
    /// <param name="putContactDto">Obiekt klasy <c>PostAndPutContactDto</c>
    /// Zawiera zmienione dane kontaktu.</param>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// edytowany kontakt jako obiekt <c>GetContactDto</c>.
    /// </returns>
    [HttpPost("edit-contact-{email}")]
    public async Task<ActionResult<ServiceResponse<GetContactDto>>> EditContact(string email,
        [FromBody] PostAndPutContactDto putContactDto)
    {
        return Ok(await _contactService.EditContact(email, putContactDto));
    }

    /// <summary>
    /// Endpoint typu DELETE usuwający kontakt o podanym adresie email.
    /// </summary>
    /// <param name="email">Adres email kontatku jako <c>string</c>.</param>
    /// <returns>
    /// Kod odpowiedzi HTTP 200 z obiektem typu <c>ServiceResponse</c> zawierającym
    /// adres email usuniętego kontaktu jako <c>string</c>.
    /// </returns>
    [HttpDelete("delete-contact-{email}")]
    public async Task<ActionResult<ServiceResponse<string>>> DeleteContact(string email)
    {
        return Ok(await _contactService.DeleteContactByEmail(email));
    }
}