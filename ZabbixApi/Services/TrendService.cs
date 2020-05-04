using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface ITrendService
    {
        IEnumerable<Trend> Get(object filter = null, IEnumerable<TrendInclude> include = null, Dictionary<string, object> @params = null);

    }
    public class TrendService : ServiceBase<Trend, TrendInclude>, ITrendService
    {
        public TrendService(IContext context) : base(context, "trend") { }
        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TrendInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            @params = @params ?? new Dictionary<string, object>();
            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("filter", filter);

            return @params;
        }

        
    }
    public enum TrendInclude
    {
        All = 1,
        None = 2
    }
}
