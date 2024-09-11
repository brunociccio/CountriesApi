using Microsoft.AspNetCore.Mvc;
using CountryAPI.Services;
using CountryAPI.Models;  

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // Endpoint para obter todos os países
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            if (countries == null || !countries.Any())
            {
                return NotFound("Nenhum país encontrado.");
            }

            return Ok(countries);
        }

        // Endpoint para obter um país específico por nome
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("O nome do país é obrigatório.");
            }

            var country = await _countryService.GetCountryByNameAsync(name);
            if (country == null)
            {
                return NotFound($"País com nome '{name}' não encontrado.");
            }

            return Ok(country);
        }
    }
}
