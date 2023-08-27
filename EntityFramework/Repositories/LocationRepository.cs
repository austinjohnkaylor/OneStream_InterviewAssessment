using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly MainDbContext _context;

    public LocationRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        return await _context.Locations.ToListAsync();
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