using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ItemServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Items.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
