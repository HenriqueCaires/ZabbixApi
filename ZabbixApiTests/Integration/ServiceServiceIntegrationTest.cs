using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ServiceServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.ServiceService.Get();
            Assert.NotNull(result);
        }
    }


}
