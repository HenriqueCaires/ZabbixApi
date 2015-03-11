using Newtonsoft.Json;
using SisMon.Zabbix.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi
{
    public interface IContext : IDisposable
    {
        T SendRequest<T>(object @params, string method);
    }

    public class Context : IContext
    {
        private readonly string _url;
        private readonly string _user;
        private readonly string _password;

        private string _authenticationToken;

        private WebClient _webClient;

        public Context()
        {
            _url = ConfigurationManager.AppSettings["ZabbixApi.url"];
            _user = ConfigurationManager.AppSettings["ZabbixApi.user"];
            _password = ConfigurationManager.AppSettings["ZabbixApi.password"];

            Check.NotEmpty(_url, "ZabbixApi.url");
            Check.NotEmpty(_user, "ZabbixApi.user");
            Check.NotEmpty(_password, "ZabbixApi.password");

            _webClient = new WebClient();

            Authenticate();
        }

        private void Authenticate()
        {
            var request = new Request();
            request.method = "user.authenticate";
            request.@params = new Dictionary<string, string>() { { "user", _user }, { "password", _password } };

            var values = new NameValueCollection();
            values.Add("content-type", "application/json-rpc");
            _webClient.Headers.Add(values);

            var responseData = _webClient.UploadData(_url, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request)));
            var responseString = Encoding.UTF8.GetString(responseData);

            _authenticationToken = JsonConvert.DeserializeObject<Response<string>>(responseString).result.ToString();
        }

        T IContext.SendRequest<T>(object @params, string method)
        {
            var id = new Random(DateTime.Now.Millisecond).Next();
            var request = new Request();
            request.method = method;
            request.@params = @params;
            request.id = id;
            request.auth = _authenticationToken;

            var values = new NameValueCollection();
            values.Add("content-type", "application/json-rpc");
            _webClient.Headers.Add(values);

            var responseData = _webClient.UploadData(_url, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request)));
            var responseString = Encoding.UTF8.GetString(responseData);

            var settings = new JsonSerializerSettings();
            settings.Converters = new JsonConverter[]{ new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter()};;
            settings.NullValueHandling = NullValueHandling.Ignore;

            var response = JsonConvert.DeserializeObject<Response<T>>(responseString, settings );

            if (response.error != null)
                throw new Exception(string.Format("Erro ao fazer request: {0}", response.error));

            if (response.id != id)
                throw new Exception(string.Format("O Id do response ({0}) não corresponde ao id do request ({1})", response.id, id));

            return response.result;
        }

        private class Request
        {
            public string jsonrpc = "2.0";
            public string method;
            public object @params;
            public int id;
            public string auth;
        }

        private class Response<T>
        {
            public string jsonrpc;
            public T result;
            public object error;
            public int id;
        }

        #region IDisposable implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        ~Context()
        {
            Dispose(false);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_webClient != null)
                {
                    _webClient.Dispose();
                    _webClient = null;
                }
            }
        }
        #endregion
    }
}
