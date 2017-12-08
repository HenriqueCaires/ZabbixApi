using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class GraphItemServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new GraphItemService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
