using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryRuleServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.DiscoveryRules.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
