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
        IEnumerable<Alert> Get(object filter = null, IEnumerable<AlertInclude> include = null, Dictionary<string, object> @params = null);
    }

    public class AlertService : ServiceBase<Alert>, IAlertService
    {
        public AlertService(IContext context) : base(context, "alert") { }

        public IEnumerable<Alert> Get(object filter = null, IEnumerable<AlertInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(AlertInclude.Hosts));
            @params.AddOrReplace("selectMediatypes", includeHelper.WhatShouldInclude(AlertInclude.MediaTypes));
            @params.AddOrReplace("selectUsers", includeHelper.WhatShouldInclude(AlertInclude.Users));

            @params.AddOrReplace("filter", filter);
            
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
