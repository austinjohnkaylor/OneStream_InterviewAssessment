using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.EntityTypeConfigurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People"); // Optional table name, you can change it as needed
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.MiddleName).HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Age).IsRequired();
        
        builder.HasData(new Person
        {
            FirstName = "John",
            MiddleName = "Cookie",
            LastName = "Doe",
            Age = 30
        }, new Person
        {
            FirstName = "Jane",
            MiddleName = "Cookie",
            LastName = "Doe",
            Age = 35
        });
    }
}