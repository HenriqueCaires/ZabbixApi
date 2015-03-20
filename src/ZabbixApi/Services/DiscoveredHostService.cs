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
    public interface IDiscoveredHostService
    {
        IList<DiscoveredHost> Get(object filter = null, IList<DiscoveredHostInclude> include = null);
    }

    public class DiscoveredHostService : ServiceBase<DiscoveredHost>, IDiscoveredHostService
    {
        public DiscoveredHostService(IContext context) : base(context, "dhost") { }

        public IList<DiscoveredHost> Get(object filter = null, IList<DiscoveredHostInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectDRules = includeHelper.WhatShouldInclude(DiscoveredHostInclude.DiscoveryRules),
                selectDServices = includeHelper.WhatShouldInclude(DiscoveredHostInclude.DiscoveredServices),

                filter = filter
            };
            return BaseGet(@params);
        }
    }

    public enum DiscoveredHostInclude
    {
        All = 1,
        None = 2,
        DiscoveryRules = 4,
        DiscoveredServices = 8
    }
}
