using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class MaintenanceServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new MaintenanceService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
