using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;
using Zabbix.Helper;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface ILLDRuleService : ICRUDService<LLDRule, LLDRuleInclude>
    {

    }

    public class LLDRuleService : CRUDService<LLDRule, LLDRuleService.LLDRulesidsResult, LLDRuleInclude>, ILLDRuleService
    {
        public LLDRuleService(IContext context) : base(context, "discoveryrule") { }

        public override IList<LLDRule> Get(object filter = null, IList<LLDRuleInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude(LLDRuleInclude.Hosts),
                selectGraphs = includeHelper.WhatShouldInclude(LLDRuleInclude.Graphs),
                selectHostPrototypes = includeHelper.WhatShouldInclude(LLDRuleInclude.HostPrototypes),
                selectItems = includeHelper.WhatShouldInclude(LLDRuleInclude.Items),
                selectTriggers = includeHelper.WhatShouldInclude(LLDRuleInclude.Triggers),

                filter = filter
            };
            return BaseGet(@params);
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
