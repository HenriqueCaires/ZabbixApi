using Xunit;
using ZabbixApi.Services;
namespace ZabbixApiTests.Integration
{
    public class ItemPrototypeServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ItemPrototypeService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}
