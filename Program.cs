using CountryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// http://localhost:5229/swagger - para acessar a documentação

// Adicionei o serviço HttpClient para CountryService
builder.Services.AddHttpClient<ICountryService, CountryService>();

// Configurações do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeamento dos endpoints da API de consulta de países [testado]
app.MapGet("/countries", async (ICountryService countryService) =>
{
    var countries = await countryService.GetAllCountriesAsync();
    return countries is not null ? Results.Ok(countries) : Results.NotFound();
})
.WithName("GetAllCountries")
.WithOpenApi();

app.MapGet("/countries/{name}", async (string name, ICountryService countryService) =>
{
    var country = await countryService.GetCountryByNameAsync(name);
    return country is not null ? Results.Ok(country) : Results.NotFound();
})
.WithName("GetCountryByName")
.WithOpenApi();

app.Run();

