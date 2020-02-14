using Xunit;

namespace ZabbixApiTests.Integration
{
    public class CorrelationServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Correlations.Get();
            Assert.NotNull(result);
        }
    }
}
