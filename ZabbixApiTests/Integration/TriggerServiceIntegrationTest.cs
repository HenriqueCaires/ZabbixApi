using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TriggerServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Triggers.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
