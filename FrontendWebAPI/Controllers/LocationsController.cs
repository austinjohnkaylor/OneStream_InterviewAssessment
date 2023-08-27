using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using FrontendWebAPI.ApiServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontendWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationApiService _locationApiService;

        public LocationsController(ILocationApiService locationApiService)
        {
            _locationApiService = locationApiService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IEnumerable<LocationDTO>> Get()
        {
            return await _locationApiService.GetAllLocations();
        }

        // // GET: api/Locations/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/Locations
        [HttpPost]
        public async Task Post([FromBody] LocationDTO newLocation)
        {
            await _locationApiService.CreateNewLocation(newLocation);
        }

        // // PUT: api/Locations/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/Locations/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
