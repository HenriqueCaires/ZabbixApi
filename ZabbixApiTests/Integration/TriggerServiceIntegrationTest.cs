using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class TriggerServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Triggers.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
