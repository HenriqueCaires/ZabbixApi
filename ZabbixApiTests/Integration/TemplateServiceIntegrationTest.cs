using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class TemplateServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Templates.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
