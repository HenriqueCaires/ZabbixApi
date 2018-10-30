using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryCheckServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.DiscoveryChecks.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
