using Xunit;

namespace ZabbixApiTests.Integration
{
    public class UserGroupServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.UserGroups.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
