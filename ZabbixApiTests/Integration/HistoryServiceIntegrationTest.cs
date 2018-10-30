using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class HistoryServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.History.Get();
                Assert.NotNull(result);
                //Assert.NotEmpty(result);
            }
        }
    }
}
