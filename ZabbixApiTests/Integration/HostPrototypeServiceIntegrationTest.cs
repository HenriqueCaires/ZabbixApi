using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class HostPrototypeServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.HostPrototypes.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
