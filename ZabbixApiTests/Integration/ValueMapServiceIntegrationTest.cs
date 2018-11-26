using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ValueMapServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.ValueMaps.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
