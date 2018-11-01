using Xunit;

namespace ZabbixApiTests.Integration
{
    public class LLDRuleServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.LLDRules.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}

