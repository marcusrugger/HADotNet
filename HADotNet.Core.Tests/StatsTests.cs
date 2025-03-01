using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class StatsTests
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
        [Ignore("Requires Home Assistant Supervisor access")]
        public async Task ShouldRetrieveSupervisorStats()
        {
            var client = ClientFactory.GetClient<StatsClient>();

            var stats = await client.GetSupervisorStats();

            Assert.AreEqual("ok", stats.Result);
            Assert.IsNotNull(stats.Data);
        }

        [Test]
        [Ignore("Requires Home Assistant Supervisor access")]
        public async Task ShouldRetrieveCoreStats()
        {
            var client = ClientFactory.GetClient<StatsClient>();

            var stats = await client.GetCoreStats();

            Assert.AreEqual("ok", stats.Result);
            Assert.IsNotNull(stats.Data);
        }
    }
}