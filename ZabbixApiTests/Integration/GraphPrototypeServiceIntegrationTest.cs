using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class GraphPrototypeServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.GraphPrototypes.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
   
    
}
