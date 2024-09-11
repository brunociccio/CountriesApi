using CountryAPI.Models;

namespace CountryAPI.Services
{
    public interface ICountryService
    {
        Task<List<Country>?> GetAllCountriesAsync();
        Task<Country?> GetCountryByNameAsync(string name);
    }
}

// http://localhost:5229/swagger - para acessar a documentação