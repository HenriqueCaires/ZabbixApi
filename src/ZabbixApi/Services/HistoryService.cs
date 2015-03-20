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
        IList<History> Get(object filter = null, IList<HistoryInclude> include = null);
    }

    public class HistoryService : ServiceBase<History>, IHistoryService
    {
        public HistoryService(IContext context) : base(context, "history") { }

        public IList<History> Get(object filter = null, IList<HistoryInclude> include = null)
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

    public enum HistoryInclude
    {
        All = 1,
        None = 2
    }
}
