using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class DiscoveryCheckServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new DiscoveryCheckService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
