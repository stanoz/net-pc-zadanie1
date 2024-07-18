
namespace zadanie1Backend.Dtos;

/// <summary>
/// Klasa DTO dla ogólnych informacji o kontakcie.
/// </summary>
public class GetGeneralContactDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public GetCategoryDto Category { get; set; }
}