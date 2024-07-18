using zadanie1Backend.Dtos.SubCategory;

namespace zadanie1Backend.Dtos;

/// <summary>
/// Klasa DTO dla pobierania kontaktu zawierająca szczegółowe informacje o kontakcie.
/// </summary>
public class GetContactDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public GetCategoryDto Category { get; set; }
    public SubCategoryDto? SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly Birthday { get; set; }
}