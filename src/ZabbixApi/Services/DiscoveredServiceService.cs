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
    public interface IDiscoveredServiceService
    {
        IEnumerable<DiscoveredService> Get(object filter = null, IEnumerable<DiscoveredServiceInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class DiscoveredServiceService : ServiceBase<DiscoveredService>, IDiscoveredServiceService
    {
        public DiscoveredServiceService(IContext context) : base(context, "dservice") { }

        public IEnumerable<DiscoveredService> Get(object filter = null, IEnumerable<DiscoveredServiceInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectDRules", includeHelper.WhatShouldInclude(DiscoveredServiceInclude.DiscoveryRules));
            @params.AddOrReplace("selectDServices", includeHelper.WhatShouldInclude(DiscoveredServiceInclude.DiscoveredServices));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(DiscoveredServiceInclude.Hosts));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }
    }

    public enum DiscoveredServiceInclude
    {
        All = 1,
        None = 2,
        DiscoveryRules = 4,
        DiscoveredServices = 8,
        Hosts = 16
    }
}
