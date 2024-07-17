using Microsoft.EntityFrameworkCore;
using zadanie1Backend.Models;

namespace zadanie1Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<SubCategory> SubCategories => Set<SubCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}