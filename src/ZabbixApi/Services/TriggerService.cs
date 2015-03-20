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

        public override IEnumerable<Trigger> Get(object filter = null, IEnumerable<TriggerInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                expandData = includeHelper.WhatShouldInclude(TriggerInclude.expandData) != null,
                expandComment = includeHelper.WhatShouldInclude(TriggerInclude.expandComment) != null,
                expandDescription = includeHelper.WhatShouldInclude(TriggerInclude.expandDescription) != null,
                expandExpression = includeHelper.WhatShouldInclude(TriggerInclude.expandExpression) != null,
                selectGroups = includeHelper.WhatShouldInclude(TriggerInclude.Groups),
                selectHosts = includeHelper.WhatShouldInclude(TriggerInclude.Hosts),
                selectItems = includeHelper.WhatShouldInclude(TriggerInclude.Items),
                selectFunctions = includeHelper.WhatShouldInclude(TriggerInclude.Functions),
                selectDependencies = includeHelper.WhatShouldInclude(TriggerInclude.Dependencies),
                selectDiscoveryRule = includeHelper.WhatShouldInclude(TriggerInclude.DiscoveryRule),
                selectLastEvent = includeHelper.WhatShouldInclude(TriggerInclude.LastEvent),

                filter = filter
            };
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
        expandData = 4,
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