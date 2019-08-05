using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IWebScenarioService : ICRUDService<WebScenario, WebScenarioInclude>
    {

    }

    public class WebScenarioService : CRUDService<WebScenario, WebScenarioService.WebScenariosidsResult, WebScenarioInclude>, IWebScenarioService
    {
        public WebScenarioService(IContext context) : base(context, "httptest") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<WebScenarioInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include?.Sum(x => (int)x) ?? 1);
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(WebScenarioInclude.Hosts));
            @params.AddOrReplace("selectSteps", includeHelper.WhatShouldInclude(WebScenarioInclude.Steps));
            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class WebScenariosidsResult : EntityResultBase
        {
            [JsonProperty("httptestids")]
            public override string[] ids { get; set; }
        }
    }

    public enum WebScenarioInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        Steps = 8
    }
}
