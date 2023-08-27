using Core.DTOs;

namespace Core.Models;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public static implicit operator Person(PersonDTO personDto)
    {
        var fullNameSplitUp = personDto.FullName.Split(" ");

        Person person = new()
        {
            FirstName = fullNameSplitUp[0],
            MiddleName = fullNameSplitUp[1],
            LastName = fullNameSplitUp[2],
            Age = personDto.Age
        };

        return person;
    }
}