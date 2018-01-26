using System.Configuration;
using ZabbixApi;

namespace ZabbixApiTests.Integration
{
    public class BaseIntegrationTest
    {
        protected string url = ConfigurationManager.AppSettings["ZabbixApi.url"];
        protected string user = "Admin";
        protected string password = "zabbix";
        protected IContext context;

        public BaseIntegrationTest() {
            this.context = new Context(url, user, password);
        }

    }
}
