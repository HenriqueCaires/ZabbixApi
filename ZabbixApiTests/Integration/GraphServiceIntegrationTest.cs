using Xunit;

namespace ZabbixApiTests.Integration
{
    public class GraphServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Graphs.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
