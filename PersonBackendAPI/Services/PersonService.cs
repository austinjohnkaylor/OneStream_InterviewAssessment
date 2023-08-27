using Core.DTOs;
using Core.Models;
using EntityFramework.Repositories;

namespace PersonBackendAPI.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<PersonDTO>> GetAllPeople()
    {
        List<PersonDTO> personDtos = new();
        var allPeople = await _personRepository.GetAllPeople();
        
        allPeople.ToList().ForEach(person =>
        {
            var personDto = new PersonDTO();
            personDto = person;
            personDtos.Add(personDto);
        });

        return personDtos;
    }

    public async Task<PersonDTO> CreateNewPerson(PersonDTO newPerson)
    {
        await _personRepository.AddPerson(newPerson);
        return newPerson;
    }

    public async Task RemoveExistingPerson(PersonDTO existingPerson)
    {
        await _personRepository.RemovePerson(existingPerson);
    }

    public async Task<Person> GetPersonByFirstMiddleAndLastName(PersonDTO existingPersonDto)
    {
        Person person = existingPersonDto;
        return await _personRepository.GetPersonByFirstMiddleAndLastName(person.FirstName, person.MiddleName, person.LastName);
    }

    public async Task<PersonDTO> GetPersonById(Guid id)
    {
        return await _personRepository.GetPersonById(id);
    }
}