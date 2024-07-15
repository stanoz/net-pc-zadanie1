namespace zadanie1Backend.Dtos;

public class PostAndPutContactDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public PostAndPutCategoryDto Category { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
}