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
    public interface IHistoryService
    {
        IEnumerable<History> Get(object filter = null, IEnumerable<HistoryInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class HistoryService : ServiceBase<History>, IHistoryService
    {
        public HistoryService(IContext context) : base(context, "history") { }

        public IEnumerable<History> Get(object filter = null, IEnumerable<HistoryInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }
    }

    public enum HistoryInclude
    {
        All = 1,
        None = 2
    }
}
