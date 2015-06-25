using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;
using ZabbixApi;
using ZabbixApi.Entities;

namespace ZabbixApi.Services
{
    public interface IHostGroupService : ICRUDService<HostGroup, HostGroupInclude>
    {

    }

    public class HostGroupService : CRUDService<HostGroup, HostGroupService.HostGroupsidsResult, HostGroupInclude>, IHostGroupService
    {
        public HostGroupService(IContext context) : base(context, "hostgroup") { }

        public override IEnumerable<HostGroup> Get(object filter = null, IEnumerable<HostGroupInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(HostGroupInclude.DiscoveryRule));
            @params.AddOrReplace("selectGroupDiscovery", includeHelper.WhatShouldInclude(HostGroupInclude.GroupDiscovery));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(HostGroupInclude.Hosts));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(HostGroupInclude.Templates));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class HostGroupsidsResult : EntityResultBase
        {
            [JsonProperty("groupids")]
            public override string[] ids { get; set; }
        }
    }

    public enum HostGroupInclude
    {
        All = 1,
        None = 2,
        DiscoveryRule = 4,
        GroupDiscovery = 8,
        Hosts = 16,
        Templates = 32
    }
}
