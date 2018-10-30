using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class UserServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.Users.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
