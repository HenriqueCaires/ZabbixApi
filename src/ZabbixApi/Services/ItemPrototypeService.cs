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

        public override IEnumerable<ItemPrototype> Get(object filter = null, IEnumerable<ItemPrototypeInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectApplications = includeHelper.WhatShouldInclude(ItemPrototypeInclude.Applications),
                selectDiscoveryRule = includeHelper.WhatShouldInclude(ItemPrototypeInclude.DiscoveryRule),
                selectGraphs = includeHelper.WhatShouldInclude(ItemPrototypeInclude.Graphs),
                selectHosts = includeHelper.WhatShouldInclude(ItemPrototypeInclude.Hosts),
                selectTriggers = includeHelper.WhatShouldInclude(ItemPrototypeInclude.Triggers),

                filter = filter
            };
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
