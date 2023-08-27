using Core.Models;

namespace Core.DTOs;

public class LocationDTO
{
    public string FullAddress { get; set; }
    
    public static implicit operator LocationDTO(Location location)
    {
        LocationDTO locationDto = new()
        {   
            FullAddress = location.Address1 + ", " + location.Address2 + ", " + location.City + ", " + location.State + ", " + location.ZipCode
        };
        return locationDto;
    }
}