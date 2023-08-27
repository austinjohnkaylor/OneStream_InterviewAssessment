using Core.DTOs;
using FrontendWebAPI.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace FrontendWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonApiService _personApiService;

    public PeopleController(IPersonApiService personApiService)
    {
        _personApiService = personApiService;
    }

    // GET: api/People
    [HttpGet]
    public async Task<IEnumerable<PersonDTO>> Get()
    {
        return await _personApiService.GetAllPeople();
    }

    // // GET: api/People/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }

    // POST: api/People
    [HttpPost]
    public async Task Post([FromBody] PersonDTO newPerson)
    {
        await _personApiService.CreateNewPerson(newPerson);
    }

    // // PUT: api/People/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    //
    // // DELETE: api/People/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}