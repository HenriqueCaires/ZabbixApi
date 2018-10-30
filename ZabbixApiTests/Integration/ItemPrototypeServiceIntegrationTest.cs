using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ItemPrototypeServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.ItemPrototypes.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
