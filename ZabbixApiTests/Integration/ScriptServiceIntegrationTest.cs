using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ScriptServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Scripts.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
