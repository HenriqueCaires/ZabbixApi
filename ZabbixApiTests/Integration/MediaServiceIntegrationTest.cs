using Xunit;
using ZabbixApi.Services;

namespace ZabbixApiTests.Integration
{
    public class MediaServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new MediaService(this.context);
            var result = service.Get();
            Assert.NotNull(result);
        }
    }
}

