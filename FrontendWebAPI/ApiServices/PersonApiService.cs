using System.Collections;
using Core.DTOs;
using Newtonsoft.Json;

namespace FrontendWebAPI.ApiServices;

public class PersonApiService : IPersonApiService
{
    private readonly HttpClient _httpClient; // https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

    public PersonApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7231/");
    }

    public async Task<IEnumerable<PersonDTO>> GetAllPeople()
    {
        var responseString = await _httpClient.GetStringAsync("api/People");

        var allPeople = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(responseString);
        return allPeople;
    }

    public async Task CreateNewPerson(PersonDTO newPerson)
    {
        await _httpClient.PostAsJsonAsync("api/People", newPerson);
    }
}