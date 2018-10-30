using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredServiceServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.DiscoveredServices.Get();
                Assert.NotNull(result);
            }
        }
    }
}
