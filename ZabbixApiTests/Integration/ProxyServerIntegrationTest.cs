using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ProxyServerIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Proxies.Get();
            Assert.NotNull(result);
        }
    }
}

