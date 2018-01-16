using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ZabbixApi
{
    public interface IContext : IDisposable
    {
        T SendRequest<T>(object @params, string method);
        Task<T> SendRequestAsync<T>(object @params, string method);

        void Authenticate(string user, string password);
        Task AuthenticateAsync(string user, string password);
    }

    public class Context : IContext
    {
        private string _url;

        private volatile string _authenticationToken;
        private WebClient _webClient;
        private HttpClient _httpClient;

        private static readonly JsonSerializerSettings _serializerSettings;

        static Context()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() }
            };
        }

        public Context()
        {
            var url = ConfigurationManager.AppSettings["ZabbixApi.url"];
            var user = ConfigurationManager.AppSettings["ZabbixApi.user"];
            var password = ConfigurationManager.AppSettings["ZabbixApi.password"];

            Initialize(url);
            Authenticate(user, password);
        }
        
        public Context(string url)
        {
            Initialize(url);
        }

        public Context(string url, string user, string password)
            : this(url)
        {
            Authenticate(user, password);
        }

        private void Initialize(string url)
        {
            Check.IsNotNullOrWhiteSpace(url, "ZabbixApi.url");

            _url = url;
            _webClient = new WebClient();
            _httpClient = new HttpClient();
        }
        
        public void Authenticate(string user, string password)
        {
            Check.IsNotNullOrWhiteSpace(user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(password, "ZabbixApi.password");

            lock (_webClient)
            {
                _authenticationToken = SendRequest<string>(
                    new Dictionary<string, string> {{"user", user}, {"password", password}},
                    "user.login",
                    null);
            }
        }

        public async Task AuthenticateAsync(string user, string password)
        {
            Check.IsNotNullOrWhiteSpace(user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(password, "ZabbixApi.password");

            _authenticationToken = await SendRequestAsync<string>(
                new Dictionary<string, string> {{"user", user}, {"password", password}},
                "user.login",
                null);
        }

        T IContext.SendRequest<T>(object @params, string method)
        {
            lock(_webClient)
            {
                var token = CheckAndGetToken();
                return SendRequest<T>(@params, method, token);
            }
        }

        private T SendRequest<T>(object @params, string method, string token)
        {
            lock(_webClient)
            {
                var request = GetRequest(@params, method, token);
                
                _webClient.Headers.Add("content-type", "application/json-rpc");
                var responseData = _webClient.UploadData(_url, Serialize(request));
                return HandleResponse<T>(request.id, responseData);
            }
        }

        private string CheckAndGetToken()
        {
            var token = _authenticationToken;
            if (token == null)
            {
                throw new InvalidOperationException("This zabbix context isn't authenticated.");
            }

            return token;
        }

        async Task<T> IContext.SendRequestAsync<T>(object @params, string method)
        {
            var token = CheckAndGetToken();
            return await SendRequestAsync<T>(@params, method, token);
        }

        private async Task<T> SendRequestAsync<T>(object @params, string method, string token)
        {
            var request = GetRequest(@params, method, token);
            var content = new ByteArrayContent(Serialize(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json-rpc");

            var response = await _httpClient.PostAsync(_url, content);
            var responseData = await response.Content.ReadAsByteArrayAsync();
            return HandleResponse<T>(request.id, responseData);
        }

        private static T HandleResponse<T>(string requestId, byte[] responseData)
        {
            var responseString = Encoding.UTF8.GetString(responseData);
            var response = JsonConvert.DeserializeObject<Response<T>>(responseString, _serializerSettings);

            if (response.error != null)
            {
                throw new Exception(response.error.message, new Exception(string.Format("{0} - code:{1}", response.error.data, response.error.code)));
            }

            if (response.id != requestId)
                throw new Exception(string.Format("O Id do response ({0}) não corresponde ao id do request ({1})", response.id, requestId));

            return response.result;
        }

        private static byte[] Serialize<T>(T value)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, _serializerSettings));
        }

        private static Request GetRequest(object @params, string method, string authenticationToken)
        {
            return new Request
            {
                method = method,
                @params = @params,
                id = Guid.NewGuid().ToString(),
                auth = authenticationToken
            };
        }

        private class Request
        {
            public string jsonrpc  { get; set; }
            public string method { get; set; }
            public object @params { get; set; }
            public string id { get; set; }
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
            public string id { get; set; }
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

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _webClient?.Dispose();
                _webClient = null;

                _httpClient?.Dispose();
                _httpClient = null;
            }
        }
        #endregion
    }
}
