using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class DiscoveryTests
    {
        private Uri Instance { get; set; }
        private string ApiKey { get; set; }

        [SetUp]
        public void Setup()
        {
            Instance = new Uri(Environment.GetEnvironmentVariable("HADotNet_Tests_Instance"));
            ApiKey = Environment.GetEnvironmentVariable("HADotNet_Tests_ApiKey");

            ClientFactory.Initialize(Instance, ApiKey);
        }

        [Test]
        [Ignore("Requires discovery endpoint to be available in Home Assistant")]
        public async Task ShouldRetrieveDiscoveryInfo()
        {
            var client = ClientFactory.GetClient<DiscoveryClient>();

            var discovery = await client.GetDiscoveryInfo();

            Assert.IsNotNull(discovery);
            Assert.IsNotEmpty(discovery.LocationName);
        }
    }
}