using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ApplicationServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Applications.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
