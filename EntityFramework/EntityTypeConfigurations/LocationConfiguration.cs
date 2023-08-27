using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.EntityTypeConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations"); // Optional table name, you can change it as needed
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.Address1).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Address2).HasMaxLength(100);
        builder.Property(l => l.City).IsRequired().HasMaxLength(50);
        builder.Property(l => l.State).IsRequired().HasMaxLength(50);
        builder.Property(l => l.ZipCode).IsRequired();

        builder.HasData(new Location
        {
            Id = Guid.NewGuid(),
            Address1 = "555 Happy Place Drive",
            Address2 = string.Empty,
            City = "Happyville",
            State = "Ohio",
            ZipCode = 55555
        }, new Location
        {
            Id = Guid.NewGuid(),
            Address1 = "123 Sycamore Tree Lane",
            Address2 = string.Empty,
            City = "Treehill",
            State = "North Carolina",
            ZipCode = 99999
        }, new Location
        {
            Id = Guid.NewGuid(),
            Address1 = "456 Broken Sticks Avenue",
            Address2 = string.Empty,
            City = "Woods",
            State = "Pennsylvania",
            ZipCode = 11111
        });
    }
}