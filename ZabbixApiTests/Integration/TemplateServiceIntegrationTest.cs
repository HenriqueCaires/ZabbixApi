using Xunit;

namespace ZabbixApiTests.Integration
{
    public class TemplateServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Templates.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
