using Xunit;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredHostServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.DiscoveredHosts.Get();
            Assert.NotNull(result);
        }
    }
}
