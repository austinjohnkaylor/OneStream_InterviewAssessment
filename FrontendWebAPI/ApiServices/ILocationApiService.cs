using Core.DTOs;

namespace FrontendWebAPI.ApiServices;

public interface ILocationApiService
{
    Task<IEnumerable<LocationDTO>> GetAllLocations();
    Task CreateNewLocation(LocationDTO newLocation);
}