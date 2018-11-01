using Xunit;

namespace ZabbixApiTests.Integration
{
    public class UserGlobalMacroServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.GlobalMacros.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
