using System;
using Xunit;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Electronics.Models;

namespace A
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Electronics.Startup>());
            HttpClient client = server.CreateClient();

            //using (var client = new TestClientProvider().Client)
            //{
            var clientResponse = await client.GetAsync("api/products");

            var responseString = await clientResponse.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);

            Assert.Equal(HttpStatusCode.OK, clientResponse.StatusCode);
            Assert.Equal(6, products.Count);
        }
    }
}
