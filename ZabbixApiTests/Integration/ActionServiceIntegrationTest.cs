using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ActionServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using(IContext context = new Context())
            {
                var result = context.Actions.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }

    
}
