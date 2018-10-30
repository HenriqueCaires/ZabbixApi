using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class UserGroupServiceIntegrationTest
    {
        [Fact]
        public void MustGetAny()
        {
            using (IContext context = new Context())
            {
                var result = context.UserGroups.Get();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
