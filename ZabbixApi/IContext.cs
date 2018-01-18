using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;
using System.Configuration;
using ZabbixApi.Services;


namespace ZabbixApi
{
    public interface IContext : IDisposable
    {
        T SendRequest<T>(object @params, string method);
    }

    public class Context : IContext
    {
        private string _url;
        private string _user;
        private string _password;

        private string _authenticationToken;
      //  private static IConfigurationRoot Configuration { get; set; }
        private WebClient _webClient;

#if !NETSTANDARD2_0
        public Context()
        {
            var url = ConfigurationManager.AppSettings["ZabbixApi.url"];
            var user = ConfigurationManager.AppSettings["ZabbixApi.user"];
            var password = ConfigurationManager.AppSettings["ZabbixApi.password"];

            Initialize(url, user, password);
        }
#endif
        
        public Context(string url, string user, string password)
        {
            Initialize(url, user, password);
        }

        private void Initialize(string url, string user, string password)
        {
            _url = url;
            _user = user;
            _password = password;

            Check.IsNotNullOrWhiteSpace(_url, "ZabbixApi.url");
            Check.IsNotNullOrWhiteSpace(_user, "ZabbixApi.user");
            Check.IsNotNullOrWhiteSpace(_password, "ZabbixApi.password");

            _webClient = new WebClient();

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

            Authenticate();
        }
        
        private void Authenticate()
        {
            var request = new Request();
            request.method = "user.login";
            request.@params = new Dictionary<string, string>() { { "user", _user }, { "password", _password } };
            //request.id = 1;
            var values = new NameValueCollection();
            values.Add("content-type", "application/json-rpc");
            _webClient.Headers.Add(values);

            var responseData = _webClient.UploadData(_url, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request)));
            var responseString = Encoding.UTF8.GetString(responseData);

            _authenticationToken = JsonConvert.DeserializeObject<Response<string>>(responseString).result.ToString();
        }

        T IContext.SendRequest<T>(object @params, string method)
        {
            lock(_webClient)
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
