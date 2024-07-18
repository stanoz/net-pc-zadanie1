using zadanie1Backend.Dtos;

namespace zadanie1Backend.Validator;

/// <summary>
/// Interfejs Validatora.
/// </summary>
public interface IValidate
{
    public bool ValidateContact(PostAndPutContactDto contact);
}