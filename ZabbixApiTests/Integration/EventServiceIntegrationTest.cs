using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class EventServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Events.Get();
                Assert.NotNull(result);
                //Assert.NotEmpty(result);
            }
        }
    }
}
