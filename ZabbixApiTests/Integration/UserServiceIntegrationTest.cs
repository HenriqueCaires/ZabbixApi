using Xunit;

namespace ZabbixApiTests.Integration
{
    public class UserServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Users.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
