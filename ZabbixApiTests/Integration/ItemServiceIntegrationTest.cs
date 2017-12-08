using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class ItemServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ItemService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
