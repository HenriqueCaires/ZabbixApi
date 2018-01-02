using System;
using Xunit;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class ContextTest : BaseIntegrationTest
    {
        private Exception ex;

        [Fact]
        public void MustNotLoginWithWrongUserData()
        {
            var url = "1";
            var username = "1";
            var password = "1";

            try
            {
                var ctx = new Context(url, username, password);
            }
            catch (Exception _ex)
            {
                ex = _ex;
            }

            Assert.NotNull(ex);
            
        }

        [Fact]
        public void MustLoginWithRightUserData()
        {
            var ctx = new Context(this.url, this.user, this.password);
            Assert.NotNull(ctx);
        }
    }
}
