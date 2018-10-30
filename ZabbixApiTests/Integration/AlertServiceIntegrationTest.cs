using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class AlertServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Alerts.Get();
                Assert.NotNull(result);
            }
        }
    }
}
