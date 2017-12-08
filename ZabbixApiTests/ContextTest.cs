using System;
using Xunit;
using ZabbixApi;

namespace ZabbixApiTests
{
    public class ContextTest
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
            var url = "http://172.21.0.25/zabbix/api_jsonrpc.php";
            var username = "Admin";
            var password = "zabbix";

            var ctx = new Context(url, username, password);
            Assert.NotNull(ctx);
        }
    }
}
