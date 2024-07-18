namespace zadanie1Backend.Models;

/// <summary>
/// Klasa kontaktu służąca do przechowywania informacji o kontakcie w bazie danych.
/// </summary>
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Category Category { get; set; }
    public SubCategory? SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly Birthday { get; set; }
}