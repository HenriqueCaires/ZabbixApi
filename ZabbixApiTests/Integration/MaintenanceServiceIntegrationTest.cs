using Xunit;

namespace ZabbixApiTests.Integration
{
    public class MaintenanceServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Maintenance.Get();
            Assert.NotNull(result);
        }
    }
}
