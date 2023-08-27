using Core.DTOs;
using Core.Models;
using Newtonsoft.Json;

namespace FrontendWebAPI.ApiServices;

public class LocationApiService : ILocationApiService
{
    private readonly HttpClient _httpClient;

    public LocationApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7160/");
    }

    public async Task<IEnumerable<LocationDTO>> GetAllLocations()
    {
        var responseString = await _httpClient.GetStringAsync("api/Locations");

        var allLocations = JsonConvert.DeserializeObject<IEnumerable<LocationDTO>>(responseString);
        return allLocations;
    }

    public async Task CreateNewLocation(LocationDTO newLocation)
    {
        await _httpClient.PostAsJsonAsync("api/Locations", newLocation);
    }
}