using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ScreenServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Screens.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
