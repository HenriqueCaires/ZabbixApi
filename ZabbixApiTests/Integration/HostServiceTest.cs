using Xunit;

namespace ZabbixApiTests.Integration
{
    public class HostServiceTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Hosts.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
