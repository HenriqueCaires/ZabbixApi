using Xunit;
using ZabbixApi;
using ZabbixApi.Services;
namespace ZabbixApiTests.Integration
{
    public class ActionServiceIntegrationTest: BaseIntegrationTest
    {
        
        [Fact]
        public void ActionServiceMustGet()
        {
            var service = new ActionService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }

    
}
