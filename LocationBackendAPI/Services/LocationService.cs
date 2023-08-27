using Core.DTOs;
using Core.Models;
using EntityFramework.Repositories;

namespace LocationBackendAPI.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<List<LocationDTO>> GetAllLocations()
    {
        List<LocationDTO> locationDtos = new();
        var allPeople = await _locationRepository.GetAllLocations();
        
        allPeople.ToList().ForEach(location =>
        {
            var locationDto = new LocationDTO();
            locationDto = location;
            locationDtos.Add(locationDto);
        });

        return locationDtos;
    }

    public async Task<LocationDTO> CreateNewLocation(LocationDTO newLocation)
    {
        await _locationRepository.AddLocation(newLocation);
        return newLocation;
    }

    public async Task RemoveExistingLocation(LocationDTO existingLocation)
    {
        await _locationRepository.RemoveLocation(existingLocation);
    }

    public async Task<Location> GetLocationByAddressCityStateAndZipcode(LocationDTO location)
    {
        return await _locationRepository.GetLocationByAddressCityStateAndZipcode(location);
    }

    public async Task<LocationDTO> GetLocationById(Guid id)
    {
        return await _locationRepository.GetLocationById(id);
    }
}