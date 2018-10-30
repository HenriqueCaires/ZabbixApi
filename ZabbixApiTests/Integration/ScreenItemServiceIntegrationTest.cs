using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ScreenItemServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.ScreenItems.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
