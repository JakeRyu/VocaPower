using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace VocaPower.Api.IntegrationTests
{
    public class WordDefinitionControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WordDefinitionControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task LookUp_ValidRequest_ReturnOkResult()
        {
            var client = _factory.CreateClient();

            string searchWord = "ace";
            var response = await client.GetAsync($"/api/WordDefinition/{searchWord}");

            response.EnsureSuccessStatusCode();
        }
    }
}