using Xunit;

namespace ZabbixApiTests.Integration
{
    public class GraphItemServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.GraphItems.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
