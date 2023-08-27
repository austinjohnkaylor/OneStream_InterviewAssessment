using Core.DTOs;

namespace Core.Models;

public class Location
{
    public Guid Id { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    
    public static implicit operator Location(LocationDTO locationDto)
    {
        var locationDtoData = locationDto.FullAddress.Split(", ");

        Location location = new()
        {
            Address1 = locationDtoData[0],
            Address2 = locationDtoData[1],
            City = locationDtoData[2],
            State = locationDtoData[3],
            ZipCode = Convert.ToInt32(locationDtoData[4])
        };

        return location;
    }
}