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
    public interface IItemService : ICRUDService<Item, ItemInclude>
    {

    }

    public class ItemService : CRUDService<Item, ItemService.ItemsidsResult, ItemInclude>, IItemService
    {
        public ItemService(IContext context) : base(context, "item") { }

        public override IEnumerable<Item> Get(object filter = null, IEnumerable<ItemInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude(ItemInclude.Hosts),
                selectInterfaces = includeHelper.WhatShouldInclude(ItemInclude.Interfaces),
                selectTriggers = includeHelper.WhatShouldInclude(ItemInclude.Triggers),
                selectGraphs = includeHelper.WhatShouldInclude(ItemInclude.Graphs),
                selectApplications = includeHelper.WhatShouldInclude(ItemInclude.Applications),
                selectDiscoveryRule = includeHelper.WhatShouldInclude(ItemInclude.DiscoveryRule),
                selectItemDiscovery = includeHelper.WhatShouldInclude(ItemInclude.ItemDiscovery),

                filter = filter
            };
            return BaseGet(@params);
        }

        public class ItemsidsResult : EntityResultBase
        {
            [JsonProperty("itemids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ItemInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        Interfaces = 8,
        Triggers = 16,
        Graphs = 32,
        Applications = 64,
        DiscoveryRule = 128,
        ItemDiscovery = 256
    }
    
}
