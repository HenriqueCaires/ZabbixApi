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
        IEnumerable<DiscoveryCheck> Get(object filter = null, IEnumerable<DiscoveryCheckInclude> include = null);
    }

    public class DiscoveryCheckService : ServiceBase<DiscoveryCheck>, IDiscoveryCheckService
    {
        public DiscoveryCheckService(IContext context) : base(context, "dcheck") { }

        public IEnumerable<DiscoveryCheck> Get(object filter = null, IEnumerable<DiscoveryCheckInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",

                filter = filter
            };
            return BaseGet(@params);
        }
    }

    public enum DiscoveryCheckInclude
    {
        All = 1,
        None = 2
    }
}
