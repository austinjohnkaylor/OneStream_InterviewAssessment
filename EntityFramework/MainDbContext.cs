using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class MainDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Location> Locations { get; set; }
    
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}