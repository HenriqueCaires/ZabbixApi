using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class ProxyServerIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ProxyService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}

