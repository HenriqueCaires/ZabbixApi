using System;
using System.Collections.Generic;
using System.Text;
using ZabbixApi.Services;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ApplicationServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ApplicationServiceMustGet()
        {
            var service = new ApplicationService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }


    }
}
