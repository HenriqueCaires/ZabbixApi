using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredHostServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.DiscoveredHosts.Get();
                Assert.NotNull(result);
            }
        }
    }
}
