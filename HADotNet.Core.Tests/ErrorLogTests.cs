using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class ErrorLogTests
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
        [Ignore("Requires error logs to be available in Home Assistant")]
        public async Task ShouldRetrieveErrorLogList()
        {
            var client = ClientFactory.GetClient<ErrorLogClient>();

            var log = await client.GetErrorLogEntries();

            Assert.IsNotNull(log);
            Assert.AreNotEqual(0, log.LogEntries.Count);
            Assert.AreNotEqual(0, log.Errors.Count);
            Assert.AreNotEqual(0, log.Warnings.Count);
            Assert.AreEqual(7, log[7].Count);
        }
    }
}