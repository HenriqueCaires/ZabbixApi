using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;
using ZabbixApi;
using Newtonsoft.Json;

namespace ZabbixApi.Services
{
    public interface IEventService
    {
        IList<Event> Get(object filter = null, IList<EventInclude> include = null);

        IList<string> Acknowledge(IList<Event> events, string message = null);

        IList<string> Acknowledge(IList<string> eventIds, string message = null);


    }

    public class EventService : ServiceBase<Event>, IEventService
    {
        public EventService(IContext context) : base(context, "event") { }

        public IList<Event> Get(object filter = null, IList<EventInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude(EventInclude.Hosts),
                selectRelatedObject = includeHelper.WhatShouldInclude(EventInclude.RelatedObject),
                select_alerts = includeHelper.WhatShouldInclude(EventInclude.Alerts),
                select_acknowledges = includeHelper.WhatShouldInclude(EventInclude.Acknowledges),


                filter = filter
            };
            return BaseGet(@params);
        }
        
        public IList<string> Acknowledge(IList<string> eventIds, string message = null)
        {
            return _context.SendRequest<EventidsResult>(
                    new 
                    {
                        eventids = eventIds,
                        message = message,
                    },
                    _className + ".acknowledge"
                    ).ids;
        }
        
        public IList<string> Acknowledge(IList<Event> events, string message = null)
        {
            return Acknowledge(events.Select(x => x.Id).ToList(), message);
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
        Acknowledges = 32
    }
}
