using Core.DTOs;
using Core.Models;

namespace LocationBackendAPI.Services;

public interface ILocationService
{
    Task<List<LocationDTO>> GetAllLocations();
    Task<LocationDTO > CreateNewLocation(LocationDTO  newLocation);
    Task RemoveExistingLocation(LocationDTO  existingLocation);
    Task<Location> GetLocationByAddressCityStateAndZipcode(LocationDTO location);
    Task<LocationDTO > GetLocationById(Guid id);
}