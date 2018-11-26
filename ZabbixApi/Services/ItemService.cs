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

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ItemInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(ItemInclude.Hosts));
            @params.AddOrReplace("selectInterfaces", includeHelper.WhatShouldInclude(ItemInclude.Interfaces));
            @params.AddOrReplace("selectTriggers", includeHelper.WhatShouldInclude(ItemInclude.Triggers));
            @params.AddOrReplace("selectGraphs", includeHelper.WhatShouldInclude(ItemInclude.Graphs));
            @params.AddOrReplace("selectApplications", includeHelper.WhatShouldInclude(ItemInclude.Applications));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(ItemInclude.DiscoveryRule));
            @params.AddOrReplace("selectItemDiscovery", includeHelper.WhatShouldInclude(ItemInclude.ItemDiscovery));
            @params.AddOrReplace("selectPreprocessing", includeHelper.WhatShouldInclude(ItemInclude.Preprocessing));
            

            @params.AddOrReplace("filter", filter);
            
            return @params;
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
        ItemDiscovery = 256,
        Preprocessing = 512,
    }
    
}
