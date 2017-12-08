using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class GraphServiceServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new GraphService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
