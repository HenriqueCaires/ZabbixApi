using Xunit;

namespace ZabbixApiTests.Integration
{
    public class EventServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Events.Get();
            Assert.NotNull(result);
        }
    }
}
