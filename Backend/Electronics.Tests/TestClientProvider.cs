using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Electronics.Tests
{
    public class TestClientProvider : IDisposable
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public void Dispose() => Client?.Dispose();
    }
}
