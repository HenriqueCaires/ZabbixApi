using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class DiscoveredServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new DiscoveredServiceService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
