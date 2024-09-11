namespace CountryAPI.Services;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using CountryAPI.Models;
using System.Collections.Generic; 

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Country>?> GetAllCountriesAsync()
    {
        var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,flags");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Country>>(content); 
        }

        return null;
    }

    public async Task<Country?> GetCountryByNameAsync(string name)
    {
        var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}?fields=name,flags");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<Country>>(content); 
            return countries?.FirstOrDefault(); 
        }

        return null;
    }
}

// http://localhost:5229/swagger - para acessar a documentação