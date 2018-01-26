using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace ZabbixApi.Services
{
    public class ApiInfoService
    {
        
        static HttpClient client = new HttpClient();
        public ApiInfoService() { }

        public string GetVersion()
        {
            var parameters = new Dictionary<string, object>();
            var uri = ConfigurationManager.AppSettings["ZabbixApi.url"];
            parameters.Add("jsonrpc", "2.0");
            parameters.Add("method", "apiinfo.version");
            parameters.Add("id", -1);
            parameters.Add("auth", null);
            parameters.Add("params", new object());
            var body = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(uri, body).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            //response.EnsureSuccessStatusCode();
            return responseContent;
            //var version = _context.SendRequest<string>(new object(), "apiinfo.version", "");
            //return version;
        }
    }
}
