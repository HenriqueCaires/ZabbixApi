using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class ScreenServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ScreenService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
