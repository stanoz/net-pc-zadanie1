using zadanie1Backend.Dtos;

namespace zadanie1Backend.Validator;

public interface IValidate
{
    public bool ValidateContact(PostAndPutCategoryDto contact);
}