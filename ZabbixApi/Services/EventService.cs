using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IEventService
    {
        IEnumerable<Event> Get(object filter = null, IEnumerable<EventInclude> include = null, Dictionary<string, object> @params = null);
        IEnumerable<string> Acknowledge(IList<Event> events, string message = null, int action = 2);
        IEnumerable<string> Acknowledge(IList<string> eventIds, string message = null, int action = 2);

        Task<IReadOnlyList<Event>> GetAsync(object filter = null, IEnumerable<EventInclude> include = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<string>> AcknowledgeAsync(IList<Event> events, string message = null, int action = 2);
        Task<IReadOnlyList<string>> AcknowledgeAsync(IList<string> eventIds, string message = null, int action = 2);
    }

    public class EventService : ServiceBase<Event, EventInclude>, IEventService
    {
        public EventService(IContext context) : base(context, "event") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<EventInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(EventInclude.Hosts));
            @params.AddOrReplace("selectRelatedObject", includeHelper.WhatShouldInclude(EventInclude.RelatedObject));
            @params.AddOrReplace("select_alerts", includeHelper.WhatShouldInclude(EventInclude.Alerts));
            @params.AddOrReplace("select_acknowledges", includeHelper.WhatShouldInclude(EventInclude.Acknowledges));
            @params.AddOrReplace("selectTags", includeHelper.WhatShouldInclude(EventInclude.Tags));
            @params.AddOrReplace("selectSuppressionData", includeHelper.WhatShouldInclude(EventInclude.SuppressionData));

            @params.AddOrReplace("filter", filter);

            return @params;
        }

        public IEnumerable<string> Acknowledge(IList<string> eventIds, string message = null, int action = 2)
        {
            return _context.SendRequest<EventidsResult>(
                    new
                    {
                        eventids = eventIds,
                        message,
                        action
                    },
                    _className + ".acknowledge"
                    ).ids;
        }

        public async Task<IReadOnlyList<string>> AcknowledgeAsync(IList<string> eventIds, string message = null, int action = 2)
        {
            return (await _context.SendRequestAsync<EventidsResult>(
                new
                {
                    eventids = eventIds,
                    message,
                    action
                },
                _className + ".acknowledge"
            )).ids;
        }

        public IEnumerable<string> Acknowledge(IList<Event> events, string message = null, int action = 2)
        {
            return Acknowledge(events.Select(x => x.Id).ToList(), message, action);
        }

        public async Task<IReadOnlyList<string>> AcknowledgeAsync(IList<Event> events, string message = null, int action = 2)
        {
            return await AcknowledgeAsync(events.Select(x => x.Id).ToList(), message, action);
        }

        public class EventidsResult : EntityResultBase
        {
            [JsonProperty("eventids")]
            public override string[] ids { get; set; }
        }

    }

    public enum EventInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        RelatedObject = 8,
        Alerts = 16,
        Acknowledges = 32,
        Tags = 64,
        SuppressionData = 128,
    }
}
