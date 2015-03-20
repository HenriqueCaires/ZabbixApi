using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;
using Zabbix.Helper;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface IDiscoveredServiceService
    {
        IList<DiscoveredService> Get(object filter = null, IList<DiscoveredServiceInclude> include = null);
    }

    public class DiscoveredServiceService : ServiceBase<DiscoveredService>, IDiscoveredServiceService
    {
        public DiscoveredServiceService(IContext context) : base(context, "dservice") { }

        public IList<DiscoveredService> Get(object filter = null, IList<DiscoveredServiceInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectDRules = includeHelper.WhatShouldInclude(DiscoveredServiceInclude.DiscoveryRules),
                selectDServices = includeHelper.WhatShouldInclude(DiscoveredServiceInclude.DiscoveredServices),
                selectHosts = includeHelper.WhatShouldInclude(DiscoveredServiceInclude.Hosts),

                filter = filter
            };
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
