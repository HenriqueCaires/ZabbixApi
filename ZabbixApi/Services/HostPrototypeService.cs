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
    public interface IHostPrototypeService : ICRUDService<HostPrototype, HostPrototypeInclude>
    {

    }

    public class HostPrototypeService : CRUDService<HostPrototype, HostPrototypeService.HostPrototypesidsResult, HostPrototypeInclude>, IHostPrototypeService
    {
        public HostPrototypeService(IContext context) : base(context, "hostprototype") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<HostPrototypeInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(HostPrototypeInclude.DiscoveryRule));
            @params.AddOrReplace("selectGroupLinks", includeHelper.WhatShouldInclude(HostPrototypeInclude.GroupLinks));
            @params.AddOrReplace("selectGroupPrototypes", includeHelper.WhatShouldInclude(HostPrototypeInclude.GroupPrototypes));
            @params.AddOrReplace("selectInventory", includeHelper.WhatShouldInclude(HostPrototypeInclude.Inventory) != null);
            @params.AddOrReplace("selectParentHost", includeHelper.WhatShouldInclude(HostPrototypeInclude.ParentHost));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(HostPrototypeInclude.Templates));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class HostPrototypesidsResult : EntityResultBase
        {
            [JsonProperty("hostids")]
            public override string[] ids { get; set; }
        }
    }

    public enum HostPrototypeInclude
    {
        All = 1,
        None = 2,
        DiscoveryRule = 4,
        GroupLinks = 8,
        GroupPrototypes = 16,
        Inventory = 32,
        ParentHost = 64,
        Templates = 128

    }
}
