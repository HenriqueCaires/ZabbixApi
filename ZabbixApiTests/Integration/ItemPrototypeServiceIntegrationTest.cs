using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ItemPrototypeServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.ItemPrototypes.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
