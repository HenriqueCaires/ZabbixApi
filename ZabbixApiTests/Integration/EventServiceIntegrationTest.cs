using System.Collections.Generic;
using Xunit;
using ZabbixApi.Entities;

namespace ZabbixApiTests.Integration
{
    public class EventServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Events.Get();
            Assert.NotNull(result);
        }
        
        [Fact]
        public void MustGetAnyAcknowledge ()
        {
            var events = new List<Event>();

            var result = context.Events.Acknowledge(events);
            Assert.NotNull(result);
        }
    }
}
