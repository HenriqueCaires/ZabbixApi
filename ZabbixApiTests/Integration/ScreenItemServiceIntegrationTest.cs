using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ScreenItemServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.ScreenItems.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
