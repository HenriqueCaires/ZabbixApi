using Xunit;

namespace ZabbixApiTests.Integration
{
    public class WebScenarioServiceTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.WebScenarios.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
