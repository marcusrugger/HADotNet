using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class LogbookTests
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
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveAllLogbookEntries()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var logEntries = await client.GetLogbookEntries();

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveLogbookEntriesByEntityId()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var history = await client.GetLogbookEntries("light.jakes_office");

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
        }

        [Test]
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveLogbookEntriesByStartDate()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var logEntries = await client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveLogbookEntriesByStartAndEndDate()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var logEntries = await client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveLogbookEntriesByStartDateAndDuration()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var logEntries = await client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), TimeSpan.FromHours(18));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        [Ignore("Requires logbook component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveLogbookEntriesByStartAndEndDateAndEntityId()
        {
            var client = ClientFactory.GetClient<LogbookClient>();

            var history = await client.GetLogbookEntries("group.family_room_lights", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
        }
    }
}