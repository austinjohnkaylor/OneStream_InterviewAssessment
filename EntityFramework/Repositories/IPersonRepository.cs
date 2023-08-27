using Core.Models;

namespace EntityFramework.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllPeople();
    Task<Person> GetPersonByFirstMiddleAndLastName(string firstName, string middleName, string lastName);
    Task AddPerson(Person person);
    Task RemovePerson(Person person);
    Task SaveChanges();
}