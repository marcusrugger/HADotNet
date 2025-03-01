using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class HistoryTests
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
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveAllHistory()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory();

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveHistoryByEntityId()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var history = await client.GetHistory("light.jakes_office");

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }

        [Test]
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveHistoryByStartDate()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveHistoryByStartAndEndDate()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveHistoryByStartDateAndDuration()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), TimeSpan.FromHours(18));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        [Ignore("Requires history component to be enabled in Home Assistant")]
        public async Task ShouldRetrieveHistoryByStartAndEndDateAndEntityId()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var history = await client.GetHistory("group.family_room_lights", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }
    }
}