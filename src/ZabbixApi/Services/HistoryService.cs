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
        IEnumerable<History> GetByType(History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetFromByType(DateTime from, History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetByType(IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetFromByType(DateTime from, IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetTextFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetNumericFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null);
    }

    public class HistoryService : ServiceBase<History>, IHistoryService
    {
        public HistoryService(IContext context) : base(context, "history") { }

        public IEnumerable<History> Get(object filter = null, IEnumerable<HistoryInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");

            @params.AddOrReplace("filter", filter);

            return BaseGet(@params);
        }

        public IEnumerable<History> GetByType(History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("history", historyType);

            var histories = Get(filter: filter, @params: @params);

            foreach (var history in histories)
            {
                history.historyType = historyType;
                yield return history;
            }
        }

        public IEnumerable<History> GetFromByType(DateTime from, History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("time_from", from.ToTimestamp());

            return GetByType(historyType: historyType, filter: filter, @params: @params);
        }

        public IEnumerable<History> GetByType(IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            return historyTypes.SelectMany(h => GetByType(historyType: h, filter: filter, @params: @params));
        }

        public IEnumerable<History> GetFromByType(DateTime from, IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            return historyTypes.SelectMany(h => GetFromByType(from: from, historyType: h, filter: filter, @params: @params));
        }

        public IEnumerable<History> GetTextFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return GetFromByType(
                    from: from, 
                    historyTypes: new History.HistoryType[] 
                    { 
                        History.HistoryType.LogType, 
                        History.HistoryType.StringType, 
                        History.HistoryType.TextType
                    }, 
                    filter: filter, 
                    @params: @params
                );
        }

        public IEnumerable<History> GetNumericFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return GetFromByType(
                    from: from,
                    historyTypes: new History.HistoryType[] 
                    { 
                        History.HistoryType.FloatType, 
                        History.HistoryType.IntegerType
                    },
                    filter: filter,
                    @params: @params
                );
        }
    }

    public enum HistoryInclude
    {
        All = 1,
        None = 2
    }
}
