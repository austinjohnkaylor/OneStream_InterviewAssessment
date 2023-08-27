using Core.Models;

namespace Core.DTOs;

public class PersonDTO
{
    public string FullName { get; set; }
    public int Age { get; set; }
    
    public static implicit operator PersonDTO(Person person)
    {
        PersonDTO personDto = new()
        {
            Age = person.Age,
            FullName = person.FirstName + " " + person.MiddleName + " " + person.LastName
        };
        return personDto;
    }
}