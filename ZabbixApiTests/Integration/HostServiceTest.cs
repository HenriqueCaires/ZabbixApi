using Xunit;
using ZabbixApi;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class HostServiceTest : BaseIntegrationTest
    {
        [Fact]
        public void HostServiceMustGetHostByName()
        {
            var service = new HostService(this.context);
            var result = service.GetByName("Zabbix server");
            Assert.NotNull(result);

        }
    }
}
