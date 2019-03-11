using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace VocaPower.Api.IntegrationTests
{
    public class LookUpHistoryControllerTests : IClassFixture<WebApplicationFactory<VocaPower.Api.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LookUpHistoryControllerTests(WebApplicationFactory<VocaPower.Api.Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/api/LookUpHistory")]
        public async Task Get_Excuted_ReturnOkResult(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}