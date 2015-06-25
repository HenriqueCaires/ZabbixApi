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
    public interface IDiscoveryCheckService
    {
        IEnumerable<DiscoveryCheck> Get(object filter = null, IEnumerable<DiscoveryCheckInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class DiscoveryCheckService : ServiceBase<DiscoveryCheck>, IDiscoveryCheckService
    {
        public DiscoveryCheckService(IContext context) : base(context, "dcheck") { }

        public IEnumerable<DiscoveryCheck> Get(object filter = null, IEnumerable<DiscoveryCheckInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }
    }

    public enum DiscoveryCheckInclude
    {
        All = 1,
        None = 2
    }
}
