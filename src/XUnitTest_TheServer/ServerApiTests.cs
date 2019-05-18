using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using TestServerExternalControllerProblem;
using Xunit;

namespace XUnitTest_TheServer
{
    public class ServerApiTests : IClassFixture<TestServerFixture<Startup>>
    {
        private readonly TestServerFixture<Startup> _fixture;

        public ServerApiTests(TestServerFixture<Startup> fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void AssureFixture()
        {
            _fixture.ShouldNotBeNull();
            var client = _fixture.Client;
            client.ShouldNotBeNull();

            var messageHandler = _fixture.MessageHandler;
            messageHandler.ShouldNotBeNull();

        }
        [Fact]
        public async Task success_app_values_api_call()
        {
            var client = _fixture.Client;
            var req = new HttpRequestMessage(HttpMethod.Get, "/api/Values")
            {
                // Content = new FormUrlEncodedContent(dict)
            };
            var response = await client.SendAsync(req);
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            var jsonString = await response.Content.ReadAsStringAsync();
            jsonString.ShouldNotBeNullOrWhiteSpace();

            var dogs = JsonConvert.DeserializeObject<List<string>>(jsonString);
            dogs.ShouldNotBeNull();
            dogs.Count.ShouldBeGreaterThan(0);

        }
        [Fact]
        public async Task success_app_valuesexternal_api_call()
        {
            var client = _fixture.Client;
            var req = new HttpRequestMessage(HttpMethod.Get, "/api/valuesexternal")
            {
                // Content = new FormUrlEncodedContent(dict)
            };
            var response = await client.SendAsync(req);
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            var jsonString = await response.Content.ReadAsStringAsync();
            jsonString.ShouldNotBeNullOrWhiteSpace();

            var dogs = JsonConvert.DeserializeObject<List<string>>(jsonString);
            dogs.ShouldNotBeNull();
            dogs.Count.ShouldBeGreaterThan(0);

        }
    }
}
