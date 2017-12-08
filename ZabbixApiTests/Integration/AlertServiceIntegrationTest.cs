using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZabbixApi.Services;
namespace ZabbixApiTests.Integration
{
    public class AlertServiceIntegrationTest : BaseIntegrationTest
    {

        [Fact]
        public void AlertServiceMustGet()
        {
            var service = new AlertService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
        
    }
}
