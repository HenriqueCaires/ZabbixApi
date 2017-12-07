using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class ScriptServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ScriptService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
