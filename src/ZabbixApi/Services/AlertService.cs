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
    public interface IAlertService
    {
        IList<Alert> Get(object filter = null, IList<AlertInclude> include = null);
    }

    public class AlertService : ServiceBase<Alert>, IAlertService
    {
        public AlertService(IContext context) : base(context, "alert") { }

        public IList<Alert> Get(object filter = null, IList<AlertInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude((int)AlertInclude.Hosts),
                selectMediatypes = includeHelper.WhatShouldInclude((int)AlertInclude.MediaTypes),
                selectUsers = includeHelper.WhatShouldInclude((int)AlertInclude.Users),

                filter = filter
            };
            return BaseGet(@params);
        }
    }

    public enum AlertInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        MediaTypes = 8,
        Users = 16
    }
}
