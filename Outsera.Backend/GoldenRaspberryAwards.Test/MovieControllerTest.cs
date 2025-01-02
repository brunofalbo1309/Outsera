using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using GoldenRaspberryAwards.API;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Test
{
    public class MovieControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MovieControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("/Movie/")]
        public async Task Get_EndpointsReturnSuccess(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/Movie/")]
        public async Task Post_EndpointsReturnSuccess(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsync(url,null);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
