using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TriggerPrototypeServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.TriggerPrototypes.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
