using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class TemplateScreenItemServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.TemplateScreenItems.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
