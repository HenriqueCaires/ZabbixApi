using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class MaintenanceServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Maintenance.Get();
                Assert.NotNull(result);
            }
        }
    }
}
