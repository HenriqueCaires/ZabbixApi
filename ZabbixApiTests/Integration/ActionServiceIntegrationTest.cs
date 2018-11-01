using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ActionServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Actions.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }


}
