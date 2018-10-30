using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class HostGroupServiceIntegrationService
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.HostGroups.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
