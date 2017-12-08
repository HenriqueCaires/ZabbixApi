using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class ImageServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new ImageService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
}
