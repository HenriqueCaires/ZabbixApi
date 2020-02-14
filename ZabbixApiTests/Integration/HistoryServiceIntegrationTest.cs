using Xunit;

namespace ZabbixApiTests.Integration
{
    public class HistoryServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.History.Get();
            Assert.NotNull(result);
        }
    }
}
