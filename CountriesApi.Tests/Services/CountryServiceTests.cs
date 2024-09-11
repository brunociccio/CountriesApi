using Xunit; 
using Moq;
using Moq.Protected; 
using Newtonsoft.Json;
using CountryAPI.Services;
using CountryAPI.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace CountryAPI.Tests.Services
{
    public class CountryServiceTests
    {
        [Fact]
        public async Task GetAllCountriesAsync_ShouldReturnListOfCountries_WhenApiCallIsSuccessful()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var countries = new List<Country>
            {
                new Country { Name = "Brazil", Flags = new Flag { Png = "flag_url.png", Svg = "flag_url.svg" } }
            };

            var responseContent = JsonConvert.SerializeObject(countries);
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var countryService = new CountryService(httpClient);

            var result = await countryService.GetAllCountriesAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Brazil", result[0].Name);
        }

        [Fact]
        public async Task GetCountryByNameAsync_ShouldReturnCountry_WhenApiCallIsSuccessful()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var countries = new List<Country>
            {
                new Country { Name = "Brazil", Flags = new Flag { Png = "flag_url.png", Svg = "flag_url.svg" } }
            };

            var responseContent = JsonConvert.SerializeObject(countries);
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var countryService = new CountryService(httpClient);

            var result = await countryService.GetCountryByNameAsync("Brazil");

            Assert.NotNull(result);
            Assert.Equal("Brazil", result.Name);
        }
    }
}
