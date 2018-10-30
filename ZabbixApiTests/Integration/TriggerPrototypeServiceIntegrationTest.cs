using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class TriggerPrototypeServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.TriggerPrototypes.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
