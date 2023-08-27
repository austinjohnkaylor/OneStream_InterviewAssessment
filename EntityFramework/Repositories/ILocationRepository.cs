using Core.Models;

namespace EntityFramework.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocations();
    Task AddLocation(Location location);
    Task RemoveLocation(Location location);
    Task SaveChanges();
}