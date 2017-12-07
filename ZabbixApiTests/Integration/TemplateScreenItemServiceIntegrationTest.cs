using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class TemplateScreenItemServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new TemplateScreenItemService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
