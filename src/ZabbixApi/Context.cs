using Newtonsoft.Json;
using ZabbixApi.Helper;
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
            request.method = "user.login";
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

            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() };

            var responseData = _webClient.UploadData(_url, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request, settings)));
            var responseString = Encoding.UTF8.GetString(responseData);

            var response = JsonConvert.DeserializeObject<Response<T>>(responseString, settings);

            if (response.error != null)
            {
                throw new Exception(response.error.message, new Exception(string.Format("{0} - code:{1}", response.error.data, response.error.code)));
            }

            if (response.id != id)
                throw new Exception(string.Format("O Id do response ({0}) não corresponde ao id do request ({1})", response.id, id));

            return response.result;
        }

        private class Request
        {
            public string jsonrpc  { get; set; }
            public string method { get; set; }
            public object @params { get; set; }
            public int id { get; set; }
            public string auth { get; set; }

            public Request()
            {
                jsonrpc = "2.0";
            }
        }

        private class Response<T>
        {
            public string jsonrpc { get; set; }
            public T result { get; set; }
            public Error error { get; set; }
            public int id { get; set; }
        }

        private class Error
        {
            public long code { get; set; }
            public string message { get; set; }
            public string data { get; set; }
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
