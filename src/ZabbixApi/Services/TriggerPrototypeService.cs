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

        public override IEnumerable<TriggerPrototype> Get(object filter = null, IEnumerable<TriggerPrototypeInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                expandData = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.expandData) != null,
                expandExpression = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.expandExpression) != null,
                selectGroups = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Groups),
                selectDiscoveryRule = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.DiscoveryRule),
                selectFunctions = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Functions),
                selectHosts = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Hosts),
                selectItems = includeHelper.WhatShouldInclude(TriggerPrototypeInclude.Items),

                filter = filter
            };
            return BaseGet(@params);
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
        expandData = 4,
        expandExpression = 8,
        Groups = 16,
        DiscoveryRule = 32,
        Functions = 64,
        Hosts = 128,
        Items = 256
    }
}
