using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;
using Zabbix.Helper;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface IEventService
    {
        IList<Event> Get(object filter = null, IList<EventInclude> include = null);
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
