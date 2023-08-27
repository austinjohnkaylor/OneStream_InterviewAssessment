using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using PersonBackendAPI.Services;

namespace PersonBackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    // GET: api/people
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var people = await _personService.GetAllPeople();
        return Ok(people);
    }
    
    // GET: api/people/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        // Assuming you have a service or repository to fetch data by ID
    var person = _personService.GetPersonById(id);

    if (person == null)
    {
        return NotFound(); // Return a Not Found result if the person with the given ID doesn't exist
    }

    return Ok(person);
    }
    
    // POST: api/people
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PersonDTO person)
    {
        if (person == null)
        {
            return BadRequest("Invalid data");
        }

        await _personService.CreateNewPerson(person);
        
        // Assuming you have a GetPersonByFirstMiddleAndLastName method
        var addedPerson = await _personService.GetPersonByFirstMiddleAndLastName(person);
        
        return CreatedAtAction(nameof(Get), new { id = addedPerson.Id }, addedPerson);
    }
}