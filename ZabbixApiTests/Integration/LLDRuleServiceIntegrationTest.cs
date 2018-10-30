using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class LLDRuleServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.LLDRules.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}

