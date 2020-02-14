using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ImageServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Images.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
