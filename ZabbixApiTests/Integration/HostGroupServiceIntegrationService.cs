using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class HostGroupServiceIntegrationService : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new HostGroupService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
