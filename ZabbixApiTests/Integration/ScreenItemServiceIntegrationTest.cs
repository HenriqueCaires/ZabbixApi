using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class ScreenItemServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ScreenItemService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
