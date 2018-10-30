using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class IconMapServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.IconMaps.Get();
                Assert.NotNull(result);
            }
        }
    }
}
