using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class HistoryServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new HistoryService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
