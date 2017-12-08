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
    public interface IDiscoveryRuleService : ICRUDService<DiscoveryRule, DiscoveryRuleInclude>
    {

    }
    public class DiscoveryRuleService : CRUDService<DiscoveryRule, DiscoveryRuleService.DiscoveryRulesidsResult, DiscoveryRuleInclude>, IDiscoveryRuleService
    {
        public DiscoveryRuleService(IContext context) : base(context, "drule") { }

        public override IEnumerable<DiscoveryRule> Get(object filter = null, IEnumerable<DiscoveryRuleInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectDHosts", includeHelper.WhatShouldInclude(DiscoveryRuleInclude.DiscoveredHosts));
            @params.AddOrReplace("selectDChecks", includeHelper.WhatShouldInclude(DiscoveryRuleInclude.DiscoveryChecks));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class DiscoveryRulesidsResult : EntityResultBase
        {
            [JsonProperty("druleids")]
            public override string[] ids { get; set; }
        }


    }

    public enum DiscoveryRuleInclude
    {
        All = 1,
        None = 2,
        DiscoveryChecks  = 4,
        DiscoveredHosts = 8
    }
}
