using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        IActionService Actions { get; }
        IAlertService Alerts { get; }
        ApiInfoService ApiInfo { get; }
        IApplicationService Applications { get; }
        ICorrelationService Correlations { get; }
        IDiscoveredHostService DiscoveredHosts { get; }
        IDiscoveredServiceService DiscoveredServices { get; }
        IDiscoveryCheckService DiscoveryChecks { get; }
        IDiscoveryRuleService DiscoveryRules { get; }
        IEventService Events { get; }
        IGraphItemService GraphItems { get; }
        IGraphPrototypeService GraphPrototypes { get; }
        IGraphService Graphs { get; }
        IHistoryService History { get; }
        IHostGroupService HostGroups { get; }
        IHostInterfaceService HostInterfaces { get; }
        IHostPrototypeService HostPrototypes { get; }
        IHostService Hosts { get; }
        IIconMapService IconMaps { get; }
        IServiceService ServiceService { get; }
        IImageService Images { get; }
        IItemPrototypeService ItemPrototypes { get; }
        IItemService Items { get; }
        ILLDRuleService LLDRules { get; }
        IMaintenanceService Maintenance { get; }
        IMapService Maps { get; }
        IMediaTypeService MediaTypes { get; }
        IProxyService Proxies { get; }
        IScreenItemService ScreenItems { get; }
        IScreenService Screens { get; }
        IScriptService Scripts { get; }
        ITemplateScreenItemService TemplateScreenItems { get; }
        ITemplateScreenService TemplateScreens { get; }
        ITemplateService Templates { get; }
        ITriggerPrototypeService TriggerPrototypes { get; }
        ITriggerService Triggers { get; }
        IUserGroupService UserGroups { get; }
        IGlobalMacroService GlobalMacros { get; }
        IHostMacroService HostMacros { get; }
        IUserService Users { get; }
        IValueMapService ValueMaps { get; }
    }

    public class Context : IContext
    {
        private string _url;

        private volatile string _authenticationToken;
        private WebClient _webClient;
        private HttpClient _httpClient;

        private JsonSerializerSettings _serializerSettings;


        public Context()
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            var configFile = "appsettings.json";

            if (!string.IsNullOrWhiteSpace(environment))
                configFile = $"appsettings.{environment}.json";

            var builder = new ConfigurationBuilder()
                            .AddJsonFile(configFile);

            var config = builder.Build();

            var url = config["ZabbixApi:url"];
            var user = config["ZabbixApi:user"];
            var password = config["ZabbixApi:password"];

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
            _serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() }
            };

            Check.IsNotNullOrWhiteSpace(url, "ZabbixApi.url");

            _url = url;
            _webClient = new WebClient();
            _httpClient = new HttpClient();

            Actions = new ActionService(this);
            Alerts = new AlertService(this);
            ApiInfo = new ApiInfoService(this);
            Applications = new ApplicationService(this);
            Correlations = new CorrelationService(this);
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
            ServiceService = new ServiceService(this);
            Images = new ImageService(this);
            ItemPrototypes = new ItemPrototypeService(this);
            Items = new ItemService(this);
            LLDRules = new LLDRuleService(this);
            Maintenance = new MaintenanceService(this);
            Maps = new MapService(this);
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
            ValueMaps = new ValueMapService(this);
        }

        public void Authenticate(string user, string password)
        {
            Check.IsNotNullOrWhiteSpace(user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(password, "ZabbixApi.password");

            lock (_webClient)
            {
                _authenticationToken = SendRequest<string>(
                    new Dictionary<string, string> { { "user", user }, { "password", password } },
                    "user.login",
                    null);
            }
        }

        public async Task AuthenticateAsync(string user, string password)
        {
            Check.IsNotNullOrWhiteSpace(user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(password, "ZabbixApi.password");

            _authenticationToken = await SendRequestAsync<string>(
                new Dictionary<string, string> { { "user", user }, { "password", password } },
                "user.login",
                null);
        }

        T IContext.SendRequest<T>(object @params, string method)
        {
            lock (_webClient)
            {
                var token = CheckAndGetToken();
                return SendRequest<T>(@params, method, token);
            }
        }

        internal T SendRequest<T>(object @params, string method, string token)
        {
            lock (_webClient)
            {
                var request = GetRequest(@params, method, token);

                _webClient.Headers.Add("content-type", "application/json-rpc");
                var responseData = _webClient.UploadData(_url, Serialize(request));
                return HandleResponse<T>(request.Id, responseData);
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

        internal async Task<T> SendRequestAsync<T>(object @params, string method, string token)
        {
            var request = GetRequest(@params, method, token);
            var content = new ByteArrayContent(Serialize(request));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json-rpc");

            var response = await _httpClient.PostAsync(_url, content);
            var responseData = await response.Content.ReadAsByteArrayAsync();
            return HandleResponse<T>(request.Id, responseData);
        }

        private T HandleResponse<T>(string requestId, byte[] responseData)
        {
            var responseString = Encoding.UTF8.GetString(responseData);
            var response = JsonConvert.DeserializeObject<Response<T>>(responseString, _serializerSettings);

            if (response.Error != null)
            {
                throw new Exception(response.Error.Message, new Exception(string.Format("{0} - code:{1}", response.Error.Data, response.Error.Code)));
            }

            if (response.Id != requestId)
                throw new Exception(string.Format("O Id do response ({0}) não corresponde ao id do request ({1})", response.Id, requestId));

            return response.Result;
        }

        private byte[] Serialize<T>(T value)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, _serializerSettings));
        }

        private Request GetRequest(object @params, string method, string authenticationToken)
        {
            return new Request
            {
                Method = method,
                Params = @params,
                Id = Guid.NewGuid().ToString(),
                Auth = authenticationToken
            };
        }

        public IActionService Actions { get; private set; }
        public IAlertService Alerts { get; private set; }
        public ApiInfoService ApiInfo { get; private set; }
        public IApplicationService Applications { get; private set; }
        public ICorrelationService Correlations { get; private set; }
        public IDiscoveredHostService DiscoveredHosts { get; private set; }
        public IDiscoveredServiceService DiscoveredServices { get; private set; }
        public IDiscoveryCheckService DiscoveryChecks { get; private set; }
        public IDiscoveryRuleService DiscoveryRules { get; private set; }
        public IEventService Events { get; private set; }
        public IGraphItemService GraphItems { get; private set; }
        public IGraphPrototypeService GraphPrototypes { get; private set; }
        public IGraphService Graphs { get; private set; }
        public IHistoryService History { get; private set; }
        public IHostGroupService HostGroups { get; private set; }
        public IHostInterfaceService HostInterfaces { get; private set; }
        public IHostPrototypeService HostPrototypes { get; private set; }
        public IHostService Hosts { get; private set; }
        public IIconMapService IconMaps { get; private set; }
        public IServiceService ServiceService { get; private set; }
        public IImageService Images { get; private set; }
        public IItemPrototypeService ItemPrototypes { get; private set; }
        public IItemService Items { get; private set; }
        public ILLDRuleService LLDRules { get; private set; }
        public IMaintenanceService Maintenance { get; private set; }
        public IMapService Maps { get; private set; }
        public IMediaTypeService MediaTypes { get; private set; }
        public IProxyService Proxies { get; private set; }
        public IScreenItemService ScreenItems { get; private set; }
        public IScreenService Screens { get; private set; }
        public IScriptService Scripts { get; private set; }
        public ITemplateScreenItemService TemplateScreenItems { get; private set; }
        public ITemplateScreenService TemplateScreens { get; private set; }
        public ITemplateService Templates { get; private set; }
        public ITriggerPrototypeService TriggerPrototypes { get; private set; }
        public ITriggerService Triggers { get; private set; }
        public IUserGroupService UserGroups { get; private set; }
        public IGlobalMacroService GlobalMacros { get; private set; }
        public IHostMacroService HostMacros { get; private set; }
        public IUserService Users { get; private set; }
        public IValueMapService ValueMaps { get; private set; }

        private class Request
        {
            [JsonProperty("jsonrpc")]
            public string JSonRCP { get; set; }
            [JsonProperty("method")]
            public string Method { get; set; }
            [JsonProperty("params")]
            public object Params { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("auth")]
            public string Auth { get; set; }

            public Request()
            {
                JSonRCP = "2.0";
            }
        }

        private class Response<T>
        {
            [JsonProperty("jsonrpc")]
            public string JSonRCP { get; set; }
            [JsonProperty("result")]
            public T Result { get; set; }
            [JsonProperty("error")]
            public Error Error { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        private class Error
        {
            [JsonProperty("code")]
            public long Code { get; set; }
            [JsonProperty("message")]
            public string Message { get; set; }
            [JsonProperty("data")]
            public string Data { get; set; }
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
