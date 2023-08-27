using Core.Models;

namespace EntityFramework.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllPeople();
    Task AddPerson(Person person);
    Task RemovePerson(Person person);
    Task SaveChanges();
}