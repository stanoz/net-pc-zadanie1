using Microsoft.IdentityModel.Tokens;
using zadanie1Backend.Dtos;

namespace zadanie1Backend.Validator;

public class Validator : IValidate
{
    public bool ValidateContact(PostAndPutCategoryDto contact)
    {
        if (contact.Name.IsNullOrEmpty())
        {
            return false;
        }

        return true;
    }
}