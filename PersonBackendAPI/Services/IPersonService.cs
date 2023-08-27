using Core.DTOs;
using Core.Models;

namespace PersonBackendAPI.Services;

public interface IPersonService
{
    Task<List<PersonDTO>> GetAllPeople();
    Task<PersonDTO> CreateNewPerson(PersonDTO newPerson);
    Task RemoveExistingPerson(PersonDTO existingPerson);
    Task<Person> GetPersonByFirstMiddleAndLastName(PersonDTO existingPersonDto);
}