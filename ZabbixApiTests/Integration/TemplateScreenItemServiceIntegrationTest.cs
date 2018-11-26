using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TemplateScreenItemServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.TemplateScreenItems.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
