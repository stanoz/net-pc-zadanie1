namespace zadanie1Backend.Dtos;

public class PostContactDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public PostCategoryDto Category { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
}