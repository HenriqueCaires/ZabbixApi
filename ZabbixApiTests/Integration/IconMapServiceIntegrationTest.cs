using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class IconMapServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new IconMapService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
