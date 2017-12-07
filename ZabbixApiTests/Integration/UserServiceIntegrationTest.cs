using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class UserServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new UserService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
