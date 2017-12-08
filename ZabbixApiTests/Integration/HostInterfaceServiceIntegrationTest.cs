using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class HostInterfaceServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new HostInterfaceService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
