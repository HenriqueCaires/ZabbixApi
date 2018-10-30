using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ItemServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Items.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
