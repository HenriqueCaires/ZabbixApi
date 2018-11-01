using Xunit;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryCheckServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.DiscoveryChecks.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
