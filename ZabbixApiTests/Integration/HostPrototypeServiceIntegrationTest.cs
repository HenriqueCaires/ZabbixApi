using Xunit;

namespace ZabbixApiTests.Integration
{
    public class HostPrototypeServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.HostPrototypes.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
