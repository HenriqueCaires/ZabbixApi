using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class GraphItemServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.GraphItems.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
