using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class HostPrototypeServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new HostPrototypeService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
