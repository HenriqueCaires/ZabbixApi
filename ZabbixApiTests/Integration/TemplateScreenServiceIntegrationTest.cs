using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class TemplateScreenServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.TemplateScreens.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
