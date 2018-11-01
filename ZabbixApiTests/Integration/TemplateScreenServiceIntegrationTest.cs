using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TemplateScreenServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.TemplateScreens.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
