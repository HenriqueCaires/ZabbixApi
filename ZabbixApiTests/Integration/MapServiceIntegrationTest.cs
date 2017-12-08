using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class MapServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new MapService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}

