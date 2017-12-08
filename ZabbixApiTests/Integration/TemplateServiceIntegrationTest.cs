using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class TemplateServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new TemplateService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
