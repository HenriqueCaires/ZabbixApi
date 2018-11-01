using Xunit;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredServiceServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.DiscoveredServices.Get();
            Assert.NotNull(result);
        }
    }
}
