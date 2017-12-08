using System;
using System.Collections.Generic;
using System.Text;
using ZabbixApi.Services;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class EventServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void EventServiceMustGet()
        {
            var service = new EventService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
