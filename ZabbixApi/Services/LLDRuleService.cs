using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;
using ZabbixApi;

namespace ZabbixApi.Services
{
    public interface ILLDRuleService : ICRUDService<LLDRule, LLDRuleInclude>
    {

    }

    public class LLDRuleService : CRUDService<LLDRule, LLDRuleService.LLDRulesidsResult, LLDRuleInclude>, ILLDRuleService
    {
        public LLDRuleService(IContext context) : base(context, "discoveryrule") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<LLDRuleInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(LLDRuleInclude.Hosts));
            @params.AddOrReplace("selectGraphs", includeHelper.WhatShouldInclude(LLDRuleInclude.Graphs));
            @params.AddOrReplace("selectHostPrototypes", includeHelper.WhatShouldInclude(LLDRuleInclude.HostPrototypes));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(LLDRuleInclude.Items));
            @params.AddOrReplace("selectTriggers", includeHelper.WhatShouldInclude(LLDRuleInclude.Triggers));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class LLDRulesidsResult : EntityResultBase
        {
            [JsonProperty("ruleids")]
            public override string[] ids { get; set; }
        }
    }

    public enum LLDRuleInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        Graphs = 8,
        HostPrototypes = 16,
        Items = 32,
        Triggers = 64
    }
}
