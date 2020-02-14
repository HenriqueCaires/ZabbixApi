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
    public interface ITriggerPrototypeService : ICRUDService<TriggerPrototype, TriggerPrototypeInclude>
    {

    }

    public class TriggerPrototypeService : CRUDService<TriggerPrototype, TriggerPrototypeService.TriggerPrototypesidsResult, TriggerPrototypeInclude>, ITriggerPrototypeService
    {
        public TriggerPrototypeService(IContext context) : base(context, "triggerprototype") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TriggerPrototypeInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("expandExpression", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.expandExpression) != null);
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Groups));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.DiscoveryRule));
            @params.AddOrReplace("selectFunctions", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Functions));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Hosts));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Items));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class TriggerPrototypesidsResult : EntityResultBase
        {
            [JsonProperty("triggerids")]
            public override string[] ids { get; set; }
        }
    }

    public enum TriggerPrototypeInclude
    {
        All = 1,
        None = 2,
        expandExpression = 8,
        Groups = 16,
        DiscoveryRule = 32,
        Functions = 64,
        Hosts = 128,
        Items = 256
    }
}
