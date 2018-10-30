using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ScriptServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Scripts.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
