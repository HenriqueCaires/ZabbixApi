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
    public interface IItemPrototypeService : ICRUDService<ItemPrototype, ItemPrototypeInclude>
    {

    }

    public class ItemPrototypeService : CRUDService<ItemPrototype, ItemPrototypeService.ItemPrototypesidsResult, ItemPrototypeInclude>, IItemPrototypeService
    {
        public ItemPrototypeService(IContext context) : base(context, "itemprototype") { }

        public override IEnumerable<ItemPrototype> Get(object filter = null, IEnumerable<ItemPrototypeInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectApplications", includeHelper.WhatShouldInclude(ItemPrototypeInclude.Applications));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(ItemPrototypeInclude.DiscoveryRule));
            @params.AddOrReplace("selectGraphs", includeHelper.WhatShouldInclude(ItemPrototypeInclude.Graphs));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(ItemPrototypeInclude.Hosts));
            @params.AddOrReplace("selectTriggers", includeHelper.WhatShouldInclude(ItemPrototypeInclude.Triggers));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class ItemPrototypesidsResult : EntityResultBase
        {
            [JsonProperty("prototypeids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ItemPrototypeInclude
    {
        All = 1,
        None = 2,
        Applications = 4,
        DiscoveryRule = 8,
        Graphs = 16,
        Hosts = 32,
        Triggers = 64
    }
}
