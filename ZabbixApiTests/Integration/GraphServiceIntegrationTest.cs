using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class GraphServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Graphs.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
