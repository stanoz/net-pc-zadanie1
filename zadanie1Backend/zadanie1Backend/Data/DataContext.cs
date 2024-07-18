using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Models;

namespace zadanie1Backend.Data;

/// <summary>
/// Klasa bazy danych.
/// Dziedziczy po <c>DbContext</c>.
/// </summary>
public class DataContext : DbContext
{
    /// <summary>
    /// Konstruktor klasy DataContext.
    /// </summary>
    /// <param name="options">Opcje dla klasy <c>DataContext</c>,
    /// przesłane do konstruktora klasy <c>DbContext.</c></param>
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    /// <summary>
    /// Metoda zwracająca zbiór danych typu <c>Contact</c>.
    /// Tworzy tabelę w bazie danych o nazwie "Contacts".
    /// </summary>
    public DbSet<Contact> Contacts => Set<Contact>();

    /// <summary>
    /// Metoda zwracająca zbiór danych typu <c>Category</c>.
    /// Tworzy tabelę w bazie danych o nazwie "Categories".
    /// </summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>
    /// Metoda zwracająca zbiór danych typu <c>SubCategory</c>.
    /// Tworzy tabelę w bazie danych o nazwie "SubCategories".
    /// </summary>
    public DbSet<SubCategory> SubCategories => Set<SubCategory>();

    /// <summary>
    /// Metoda konfiguruje schemat potrzebny dla bazy danych przed zablokowaniem modelu i
    /// użyciem go do inicjalizacji bazy danych.
    /// </summary>
    /// <param name="modelBuilder">
    ///  Definiuje kształt encji, relacje między nimi oraz sposób mapowania na bazę danych.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /// Pole Email w encji Contact jest unikalne.
        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}