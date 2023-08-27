using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repositories;

public class PersonRepository : IPersonRepository
{
 private readonly MainDbContext _context;

    public PersonRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<Person> GetPersonByFirstMiddleAndLastName(string firstName, string middleName, string lastName)
    {
        return await _context.People.FirstOrDefaultAsync(person =>
            person.FirstName == firstName && person.MiddleName == middleName && person.LastName == lastName);
    }

    public async Task AddPerson(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task RemovePerson(Person person)
    {
        var existingPerson = await _context.People.FindAsync(person.Id);
        
        if (existingPerson != null)
        {
            _context.People.Remove(existingPerson);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}