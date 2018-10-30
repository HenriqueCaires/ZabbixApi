using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ApplicationServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Applications.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
