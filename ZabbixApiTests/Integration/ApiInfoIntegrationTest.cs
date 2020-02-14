using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ApiInfoIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.ApiInfo.GetVersion();
            Assert.NotNull(result);
        }
    }
}
