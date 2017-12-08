using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryRuleIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new DiscoveryRuleService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }

    }
}
