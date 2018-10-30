using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class BaseIntegrationTest
    {
        protected string url = "http://MyZabbixServer:43210/api_jsonrpc.php";
        protected string user = "Admin";
        protected string password = "zabbix";
        protected IContext context;

        public BaseIntegrationTest() {
            this.context = new Context(url, user, password);
        }

    }
}
