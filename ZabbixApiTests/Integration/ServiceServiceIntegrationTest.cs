using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ServiceServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using(IContext context = new Context())
            {
                var result = context.ServiceService.Get();
                Assert.NotNull(result);
            }
        }
    }

    
}
