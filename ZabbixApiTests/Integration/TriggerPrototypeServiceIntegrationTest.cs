using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class TriggerPrototypeServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new TriggerPrototypeService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
