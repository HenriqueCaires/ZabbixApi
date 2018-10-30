using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ImageServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Images.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
