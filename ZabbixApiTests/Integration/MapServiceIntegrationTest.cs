using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class MapServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Maps.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}

