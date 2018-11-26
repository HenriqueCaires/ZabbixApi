using Xunit;

namespace ZabbixApiTests.Integration
{
    public class AlertServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Alerts.Get();
            Assert.NotNull(result);
        }
    }
}
