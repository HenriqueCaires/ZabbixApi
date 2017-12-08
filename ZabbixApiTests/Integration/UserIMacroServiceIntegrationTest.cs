using Xunit;
using ZabbixApi.Services;


namespace ZabbixApiTests.Integration
{
    public class UserIMacroServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new GlobalMacroService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }

    }
}
