using System;
using System.Collections.Generic;
using System.Text;
using ZabbixApi.Services;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class GraphPrototypeServiceIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void ServiceMustGet()
        {
            var service = new GraphPrototypeService(this.context);
            var result = service.Get();
            Assert.NotNull(result);

        }
    }
   
    
}
