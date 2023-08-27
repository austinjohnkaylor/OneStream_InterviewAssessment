using Core.DTOs;

namespace FrontendWebAPI.ApiServices;

public interface IPersonApiService
{
    Task<IEnumerable<PersonDTO>> GetAllPeople();
    Task CreateNewPerson(PersonDTO newPerson);
}