using Core.DTOs;
using LocationBackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationBackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

 // GET: api/Locations
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var locations = await _locationService.GetAllLocations();
        return Ok(locations);
    }

    // GET: api/Locations/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var location = await _locationService.GetLocationById(id);

        if (location == null)
        {
            return NotFound(); // Return a Not Found result if the location with the given ID doesn't exist
        }

        return Ok(location);
    }

    // POST: api/Locations
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LocationDTO location)
    {
        if (location == null)
        {
            return BadRequest("Invalid data");
        }

        await _locationService.CreateNewLocation(location);

        var newLocation = await _locationService.GetLocationByAddressCityStateAndZipcode(location);

        return CreatedAtAction(nameof(Get), new { id = newLocation.Id }, newLocation);
    }

    // DELETE: api/Locations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var location = await _locationService.GetLocationById(id);

        if (location == null)
        {
            return NotFound(); // Return a Not Found result if the location with the given ID doesn't exist
        }

        await _locationService.RemoveExistingLocation(location);

        return NoContent();
    }
}