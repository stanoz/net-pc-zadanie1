namespace zadanie1Backend.Models;

/// <summary>
/// Klasa służąca do przechowywania informacji o odpowiedzi serwisu.
/// </summary>
/// <typeparam name="T">
/// Typ danych zwracanych w odpowiedzi.
/// </typeparam>
public class ServiceResponse<T>
{
    /// <summary>
    /// Typ danych zwracanych w odpowiedzi.
    /// Zawiera dane zwracane w odpowiedzi.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Inormacja o powodzeniu operacji.
    /// true - operacja zakończona powodzeniem.
    /// false - operacja zakończona niepowodzeniem.
    /// </summary>
    public bool Success { get; set; } = true;

    /// <summary>
    /// Wiadomość zwracana w odpowiedzi.
    /// Zawiera informacje o błędach lub powodzeniu operacji.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}