using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZabbixApi.Helper;
using ZabbixApi.Services;

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
        private volatile string _user;
        private volatile string _password;

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

#if !NETSTANDARD2_0
        public Context()
        {
            var url = ConfigurationManager.AppSettings["ZabbixApi.url"];
            var user = ConfigurationManager.AppSettings["ZabbixApi.user"];
            var password = ConfigurationManager.AppSettings["ZabbixApi.password"];

            Initialize(url);
            Authenticate(user, password);
        }
#endif
        
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

            Actions = new ActionService(this);
            Alerts = new AlertService(this);
            ApiInfo = new ApiInfoService(this);
            Applications = new ApplicationService(this);
            DiscoveredHosts = new DiscoveredHostService(this);
            DiscoveredServices = new DiscoveredServiceService(this);
            DiscoveryChecks = new DiscoveryCheckService(this);
            DiscoveryRules = new DiscoveryRuleService(this);
            Events = new EventService(this);
            GraphItems = new GraphItemService(this);
            GraphPrototypes = new GraphPrototypeService(this);
            Graphs = new GraphService(this);
            History = new HistoryService(this);
            HostGroups = new HostGroupService(this);
            HostInterfaces = new HostInterfaceService(this);
            HostPrototypes = new HostPrototypeService(this);
            Hosts = new HostService(this);
            IconMaps = new IconMapService(this);
            ITServiceService = new ITServiceService(this);
            Images = new ImageService(this);
            ItemPrototypes = new ItemPrototypeService(this);
            Items = new ItemService(this);
            LLDRules = new LLDRuleService(this);
            Maintenance = new MaintenanceService(this);
            Maps = new MapService(this);
            Medias = new MediaService(this);
            MediaTypes = new MediaTypeService(this);
            Proxies = new ProxyService(this);
            ScreenItems = new ScreenItemService(this);
            Screens = new ScreenService(this);
            Scripts = new ScriptService(this);
            TemplateScreenItems = new TemplateScreenItemService(this);
            TemplateScreens = new TemplateScreenService(this);
            Templates = new TemplateService(this);
            TriggerPrototypes = new TriggerPrototypeService(this);
            Triggers = new TriggerService(this);
            UserGroups = new UserGroupService(this);
            GlobalMacros = new GlobalMacroService(this);
            HostMacros = new HostMacroService(this);
            Users = new UserService(this);
        }
        
        public void Authenticate(string user, string password)
        {
            Check.IsNotNullOrWhiteSpace(user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(password, "ZabbixApi.password");

            _user = user;
            _password = password;

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

            _user = user;
            _password = password;

            _authenticationToken = await SendRequestAsync<string>(
                new Dictionary<string, string> {{"user", user}, {"password", password}},
                "user.login",
                null);
        }

        T IContext.SendRequest<T>(object @params, string method)
        {
            lock(_webClient)
            {
                try
                {
                    var token = CheckAndGetToken();
                    return SendRequest<T>(@params, method, token, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Authenticate(_user, _password);
                    var token = CheckAndGetToken();
                    return SendRequest<T>(@params, method, token);
                }
            }
        }

        internal T SendRequest<T>(object @params, string method, string token, bool reAuth = false)
        {
            lock(_webClient)
            {
                var request = GetRequest(@params, method, token);
                
                _webClient.Headers.Add("content-type", "application/json-rpc");
                var responseData = _webClient.UploadData(_url, Serialize(request));
                return HandleResponse<T>(request.id, responseData, reAuth);
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
            try
            {
                var token = CheckAndGetToken();
                return await SendRequestAsync<T>(@params, method, token, true);
            }
            catch (UnauthorizedAccessException)
            {
                await AuthenticateAsync(_user, _password);
                var token = CheckAndGetToken();
                return await SendRequestAsync<T>(@params, method, token);
            }
        }

        internal async Task<T> SendRequestAsync<T>(object @params, string method, string token, bool reAuth = false)
        {
            var request = GetRequest(@params, method, token);
            var content = new ByteArrayContent(Serialize(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json-rpc");

            var response = await _httpClient.PostAsync(_url, content);
            var responseData = await response.Content.ReadAsByteArrayAsync();
            return HandleResponse<T>(request.id, responseData, reAuth);
        }

        private static T HandleResponse<T>(string requestId, byte[] responseData, bool reAuth)
        {
            var responseString = Encoding.UTF8.GetString(responseData);
            var response = JsonConvert.DeserializeObject<Response<T>>(responseString, _serializerSettings);

            if (response.error != null)
            {
                if (reAuth && IsSessionExpiredError(response.error))
                {
                    throw new UnauthorizedAccessException("Session expired");
                }
                throw new Exception(response.error.message, new Exception(string.Format("{0} - code:{1}", response.error.data, response.error.code)));
            }

            if (response.id != requestId)
                throw new Exception(string.Format("O Id do response ({0}) não corresponde ao id do request ({1})", response.id, requestId));

            return response.result;
        }

        private static bool IsSessionExpiredError(Error error)
        {
            return error.code == -32602 && error.data == "Session terminated, re-login, please.";
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

        public ActionService Actions { get; private set; }
        public AlertService Alerts { get; private set; }
        public ApiInfoService ApiInfo { get; private set; }
        public ApplicationService Applications { get; private set; }
        public DiscoveredHostService DiscoveredHosts { get; private set; }
        public DiscoveredServiceService DiscoveredServices { get; private set; }
        public DiscoveryCheckService DiscoveryChecks { get; private set; }
        public DiscoveryRuleService DiscoveryRules { get; private set; }
        public EventService Events { get; private set; }
        public GraphItemService GraphItems { get; private set; }
        public GraphPrototypeService GraphPrototypes { get; private set; }
        public GraphService Graphs { get; private set; }
        public HistoryService History { get; private set; }
        public HostGroupService HostGroups { get; private set; }
        public HostInterfaceService HostInterfaces { get; private set; }
        public HostPrototypeService HostPrototypes { get; private set; }
        public HostService Hosts { get; private set; }
        public IconMapService IconMaps { get; private set; }
        public ITServiceService ITServiceService { get; private set; }
        public ImageService Images { get; private set; }
        public ItemPrototypeService ItemPrototypes { get; private set; }
        public ItemService Items { get; private set; }
        public LLDRuleService LLDRules { get; private set; }
        public MaintenanceService Maintenance { get; private set; }
        public MapService Maps { get; private set; }
        public MediaService Medias { get; private set; }
        public MediaTypeService MediaTypes { get; private set; }
        public ProxyService Proxies { get; private set; }
        public ScreenItemService ScreenItems { get; private set; }
        public ScreenService Screens { get; private set; }
        public ScriptService Scripts { get; private set; }
        public TemplateScreenItemService TemplateScreenItems { get; private set; }
        public TemplateScreenService TemplateScreens { get; private set; }
        public TemplateService Templates { get; private set; }
        public TriggerPrototypeService TriggerPrototypes { get; private set; }
        public TriggerService Triggers { get; private set; }
        public UserGroupService UserGroups { get; private set; }
        public GlobalMacroService GlobalMacros { get; private set; }
        public HostMacroService HostMacros { get; private set; }
        public UserService Users { get; private set; }

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
