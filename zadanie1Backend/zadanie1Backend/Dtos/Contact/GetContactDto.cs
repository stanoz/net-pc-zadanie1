using zadanie1Backend.Dtos.SubCategory;

namespace zadanie1Backend.Dtos;

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