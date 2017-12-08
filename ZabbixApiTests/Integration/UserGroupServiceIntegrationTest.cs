using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class UserGroupServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new UserGroupService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
