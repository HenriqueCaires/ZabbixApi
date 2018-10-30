using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class UserGlobalMacroServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.GlobalMacros.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
