using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class LLDRuleServiceIntegrationTest: BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new LLDRuleService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}

