using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class TriggerServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new TriggerService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
