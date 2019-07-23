using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

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
        
        Task<IReadOnlyList<History>> GetByTypeAsync(History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<History>> GetFromByTypeAsync(DateTime from, History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<History>> GetByTypeAsync(IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<History>> GetFromByTypeAsync(DateTime from, IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null);
        IEnumerable<History> GetTextFromAsync(DateTime from, object filter = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<History>> GetNumericFromAsync(DateTime from, object filter = null, Dictionary<string, object> @params = null);
    }

    public class HistoryService : ServiceBase<History, HistoryInclude>, IHistoryService
    {
        private static readonly History.HistoryType[] _textHistoryTypes =
        { 
            History.HistoryType.LogType, 
            History.HistoryType.StringType, 
            History.HistoryType.TextType
        };

        private static readonly History.HistoryType[] _numericHistoryTypes =
        { 
            History.HistoryType.FloatType, 
            History.HistoryType.IntegerType
        };

        public HistoryService(IContext context) : base(context, "history") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<HistoryInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            @params = @params ?? new Dictionary<string, object>();
            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("filter", filter);
            @params.AddOrReplace("limit", "10");

            return @params;
        }

        public IEnumerable<History> GetByType(History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            @params = @params ?? new Dictionary<string, object>();
            @params.AddOrReplace("history", historyType);

            var histories = Get(filter: filter, @params: @params);

            foreach (var history in histories)
            {
                history.historyType = historyType;
                yield return history;
            }
        }

        public async Task<IReadOnlyList<History>> GetByTypeAsync(History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            @params = @params ?? new Dictionary<string, object>();
            @params.AddOrReplace("history", historyType);

            var histories = await GetAsync(filter: filter, @params: @params);

            foreach (var history in histories)
            {
                history.historyType = historyType;
            }

            return histories;
        }

        public IEnumerable<History> GetFromByType(DateTime from, History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            @params = @params ?? new Dictionary<string, object>();
            @params.AddOrReplace("time_from", from.ToTimestamp());

            return GetByType(historyType: historyType, filter: filter, @params: @params);
        }

        public async Task<IReadOnlyList<History>> GetFromByTypeAsync(DateTime from, History.HistoryType historyType, object filter = null, Dictionary<string, object> @params = null)
        {
            @params = @params ?? new Dictionary<string, object>();
            @params.AddOrReplace("time_from", from.ToTimestamp());

            return await GetByTypeAsync(historyType: historyType, filter: filter, @params: @params);
        }

        public IEnumerable<History> GetByType(IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            return historyTypes.SelectMany(h => GetByType(historyType: h, filter: filter, @params: @params));
        }

        public async Task<IReadOnlyList<History>> GetByTypeAsync(IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            var result = new List<History>();
            foreach (var historyType in historyTypes)
            {
                var values = await GetByTypeAsync(historyType: historyType, filter: filter, @params: @params);
                result.AddRange(values);
            }
            return result;
        }

        public IEnumerable<History> GetFromByType(DateTime from, IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            return historyTypes.SelectMany(h => GetFromByType(from: from, historyType: h, filter: filter, @params: @params));
        }

        public async Task<IReadOnlyList<History>> GetFromByTypeAsync(DateTime from, IEnumerable<History.HistoryType> historyTypes, object filter = null, Dictionary<string, object> @params = null)
        {
            var result = new List<History>();
            foreach (var historyType in historyTypes)
            {
                var values = await GetFromByTypeAsync(from: from, historyType: historyType, filter: filter, @params: @params);
                result.AddRange(values);
            }
            return result;
        }

        public IEnumerable<History> GetTextFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return GetFromByType(
                    from: from, 
                    historyTypes: _textHistoryTypes, 
                    filter: filter, 
                    @params: @params
                );
        }

        public IEnumerable<History> GetTextFromAsync(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return GetFromByType(
                from: from, 
                historyTypes: _textHistoryTypes, 
                filter: filter, 
                @params: @params
            );
        }

        public IEnumerable<History> GetNumericFrom(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return GetFromByType(
                    from: from,
                    historyTypes: _numericHistoryTypes,
                    filter: filter,
                    @params: @params
                );
        }

        public async Task<IReadOnlyList<History>> GetNumericFromAsync(DateTime from, object filter = null, Dictionary<string, object> @params = null)
        {
            return await GetFromByTypeAsync(
                from: from,
                historyTypes: _numericHistoryTypes,
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
