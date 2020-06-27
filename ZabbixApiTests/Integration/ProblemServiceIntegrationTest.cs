using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ZabbixApiTests.Integration
{
    public class ProblemServiceIntegrationTest : IntegrationTestBase
    {
        [Fact]
        public void MustGetAny()
        {
            var result = context.Problem.Get().Where(x => x._objectid == "55578").ToList();
            Assert.NotNull(result);
        }
    }
}
