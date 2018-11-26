using Xunit;

namespace ZabbixApiTests.Integration
{
    public class HostInterfaceServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.HostInterfaces.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
