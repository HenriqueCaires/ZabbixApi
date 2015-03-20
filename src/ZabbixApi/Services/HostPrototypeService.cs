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

        public override IEnumerable<HostPrototype> Get(object filter = null, IEnumerable<HostPrototypeInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectDiscoveryRule = includeHelper.WhatShouldInclude(HostPrototypeInclude.DiscoveryRule),
                selectGroupLinks = includeHelper.WhatShouldInclude(HostPrototypeInclude.GroupLinks),
                selectGroupPrototypes = includeHelper.WhatShouldInclude(HostPrototypeInclude.GroupPrototypes),
                selectInventory = includeHelper.WhatShouldInclude(HostPrototypeInclude.Inventory) != null,
                selectParentHost = includeHelper.WhatShouldInclude(HostPrototypeInclude.ParentHost),
                selectTemplates = includeHelper.WhatShouldInclude(HostPrototypeInclude.Templates),

                filter = filter
            };
            return BaseGet(@params);
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
