using Xunit;

namespace ZabbixApiTests.Integration
{
    public class HostGroupServiceIntegrationService : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.HostGroups.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
