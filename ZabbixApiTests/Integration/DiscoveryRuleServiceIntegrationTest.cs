using Xunit;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryRuleServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.DiscoveryRules.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
