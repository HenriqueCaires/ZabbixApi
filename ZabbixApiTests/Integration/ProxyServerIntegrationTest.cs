using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ProxyServerIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Proxies.Get();
                Assert.NotNull(result);
            }
        }
    }
}

