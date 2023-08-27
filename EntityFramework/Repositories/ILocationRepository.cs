using Core.DTOs;
using Core.Models;

namespace EntityFramework.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocations();
    Task<Location> GetLocationById(Guid id);
    Task<Location> GetLocationByAddressCityStateAndZipcode(LocationDTO location);
    Task AddLocation(Location location);
    Task RemoveLocation(Location location);
    Task SaveChanges();
}