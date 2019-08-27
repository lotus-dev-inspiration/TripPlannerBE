using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace TripPlannerBE.IntegrationTests
{
    public class UsersControllerIntegrationTest : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;


        public UsersControllerIntegrationTest(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void Test1()
        {
            // Arrange
            var request = new HttpRequestMessage(
                HttpMethod.Get, "/users");

            // Act: request the /users route
            var response = await _client.SendAsync(request);

            // Assert: the user is sent to the login page
            Assert.Equal(
                HttpStatusCode.OK,
                response.StatusCode);

            //Assert.Equal(
            //    "http://localhost:8888/Account" +
            //    "/Login?ReturnUrl=%2Ftodo",
            //    response.Headers.Location.ToString());
        }
    }
}
