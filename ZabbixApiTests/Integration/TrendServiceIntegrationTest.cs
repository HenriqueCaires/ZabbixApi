using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TrendServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Trend.Get();
            Assert.NotNull(result);
        }
    }
}
