using Core.DTOs;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly MainDbContext _context;

    public LocationRepository(MainDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated(); // ensures the seeding data setup in LocationConfiguration gets populated in the Database
    }

    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<Location> GetLocationById(Guid id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public async Task<Location> GetLocationByAddressCityStateAndZipcode(LocationDTO location)
    {
        Location searchedLocation = location;
        var newLocation = await _context.Locations.FirstOrDefaultAsync(a =>
            a.Address1 == searchedLocation.Address1 && a.Address2 == searchedLocation.Address2 &&
            a.City == searchedLocation.City && a.State == searchedLocation.State &&
            a.ZipCode == searchedLocation.ZipCode);

        return newLocation;
    }

    public async Task AddLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveLocation(Location location)
    {
        var existingLocation = await _context.Locations.FindAsync(location.Id);

        if (existingLocation != null)
        {
            _context.Locations.Remove(existingLocation);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}