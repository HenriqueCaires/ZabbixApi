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
    public interface IAlertService
    {
        IEnumerable<Alert> Get(object filter = null, IEnumerable<AlertInclude> include = null);
    }

    public class AlertService : ServiceBase<Alert>, IAlertService
    {
        public AlertService(IContext context) : base(context, "alert") { }

        public IEnumerable<Alert> Get(object filter = null, IEnumerable<AlertInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude(AlertInclude.Hosts),
                selectMediatypes = includeHelper.WhatShouldInclude(AlertInclude.MediaTypes),
                selectUsers = includeHelper.WhatShouldInclude(AlertInclude.Users),

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
