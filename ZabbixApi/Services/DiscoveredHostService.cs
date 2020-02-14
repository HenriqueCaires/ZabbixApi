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
    public interface IDiscoveredHostService
    {
        IEnumerable<DiscoveredHost> Get(object filter = null, IEnumerable<DiscoveredHostInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class DiscoveredHostService : ServiceBase<DiscoveredHost, DiscoveredHostInclude>, IDiscoveredHostService
    {
        public DiscoveredHostService(IContext context) : base(context, "dhost") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<DiscoveredHostInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectDRules", includeHelper.WhatShouldInclude(DiscoveredHostInclude.DiscoveryRules));
            @params.AddOrReplace("selectDServices", includeHelper.WhatShouldInclude(DiscoveredHostInclude.DiscoveredServices));

            @params.AddOrReplace("filter", filter);
            
            return @params;
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
