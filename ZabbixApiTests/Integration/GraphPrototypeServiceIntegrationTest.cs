using Xunit;

namespace ZabbixApiTests.Integration
{
    public class GraphPrototypeServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.GraphPrototypes.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }


}
