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
    public interface ITriggerService : ICRUDService<Trigger, TriggerInclude>
    {

    }

    public class TriggerService : CRUDService<Trigger, TriggerService.TriggersidsResult, TriggerInclude>, ITriggerService
    {
        public TriggerService(IContext context) : base(context, "trigger") { }

        public override IEnumerable<Trigger> Get(object filter = null, IEnumerable<TriggerInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("expandComment", includeHelper.WhatShouldInclude(TriggerInclude.expandComment) != null);
            @params.AddOrReplace("expandDescription", includeHelper.WhatShouldInclude(TriggerInclude.expandDescription) != null);
            @params.AddOrReplace("expandExpression", includeHelper.WhatShouldInclude(TriggerInclude.expandExpression) != null);
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(TriggerInclude.Groups));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(TriggerInclude.Hosts));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(TriggerInclude.Items));
            @params.AddOrReplace("selectFunctions", includeHelper.WhatShouldInclude(TriggerInclude.Functions));
            @params.AddOrReplace("selectDependencies", includeHelper.WhatShouldInclude(TriggerInclude.Dependencies));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(TriggerInclude.DiscoveryRule));
            @params.AddOrReplace("selectLastEvent", includeHelper.WhatShouldInclude(TriggerInclude.LastEvent));
            
            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class TriggersidsResult : EntityResultBase
        {
            [JsonProperty("triggerids")]
            public override string[] ids { get; set; }
        }
    }

    public enum TriggerInclude
    {
        All = 1,
        None = 2,
        expandComment = 8,
        expandDescription = 16,
        expandExpression = 32,
        Groups = 64,
        Hosts = 128,
        Items = 256,
        Functions = 512,
        Dependencies = 1024,
        DiscoveryRule = 2048,
        LastEvent = 4096
    }
}