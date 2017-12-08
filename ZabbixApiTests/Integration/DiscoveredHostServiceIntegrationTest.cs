using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredHostServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void DiscoveredHostServiceeMustGet()
        {
            var service = new DiscoveredHostService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }

    }
}
