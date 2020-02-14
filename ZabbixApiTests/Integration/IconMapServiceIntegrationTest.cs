using Xunit;

namespace ZabbixApiTests.Integration
{
    public class IconMapServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.IconMaps.Get();
            Assert.NotNull(result);
        }
    }
}
