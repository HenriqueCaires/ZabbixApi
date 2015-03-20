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

        public override IEnumerable<HostGroup> Get(object filter = null, IEnumerable<HostGroupInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectDiscoveryRule = includeHelper.WhatShouldInclude(HostGroupInclude.DiscoveryRule),
                selectGroupDiscovery = includeHelper.WhatShouldInclude(HostGroupInclude.GroupDiscovery),
                selectHosts = includeHelper.WhatShouldInclude(HostGroupInclude.Hosts),
                selectTemplates = includeHelper.WhatShouldInclude(HostGroupInclude.Templates),

                filter = filter
            };
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
