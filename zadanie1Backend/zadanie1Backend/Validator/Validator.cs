using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using zadanie1Backend.Dtos;

namespace zadanie1Backend.Validator;

/// <summary>
/// Validator.
/// Sprawdza poprawność danych.
/// Implementuje interfejs IValidate.
/// </summary>
public class Validator : IValidate
{
    /// <summary>
    /// Metoda sprawdzająca poprawność danych kontaktu.
    /// </summary>
    /// <param name="contact">Kontakt do sprawdzenia typu <c>PostAndPutContactDto</c></param>
    /// <returns>
    /// Zwraca true jeśli dane są poprawne, w przeciwnym wypadku false.
    /// </returns>
    public bool ValidateContact(PostAndPutContactDto contact)
    {
        if (contact.Name.IsNullOrEmpty())
        {
            return false;
        }

        if (contact.Surname.IsNullOrEmpty())
        {
            return false;
        }

        const string EmailPattern = @"^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$";
        if (!Regex.IsMatch(contact.Email, EmailPattern))
        {
            return false;
        }

        const string PasswordPattern = @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$";
        if (!Regex.IsMatch(contact.Password, PasswordPattern))
        {
            return false;
        }

        if (contact.Category.Name.IsNullOrEmpty())
        {
            return false;
        }

        const string PhoneNumberPattern = @"^\d{3}(-| )?\d{3}(-| )?\d{3}$";
        if (!Regex.IsMatch(contact.PhoneNumber, PhoneNumberPattern))
        {
            return false;
        }

        /// Sprawdzenie czy data urodzenia jest poprawna.
        if (contact.Birthday > DateOnly.FromDateTime(DateTime.Now))
        {
            return false;
        }
        
        return true;
    }
}