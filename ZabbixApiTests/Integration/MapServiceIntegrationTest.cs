using Xunit;

namespace ZabbixApiTests.Integration
{
    public class MapServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Maps.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}

