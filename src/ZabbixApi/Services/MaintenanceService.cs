using Newtonsoft.Json;
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
    public interface IMaintenanceService : ICRUDService<Maintenance, MaintenanceInclude>
    {

    }

    public class MaintenanceService : CRUDService<Maintenance, MaintenanceService.MaintenancesidsResult, MaintenanceInclude>, IMaintenanceService
    {
        public MaintenanceService(IContext context) : base(context, "discoveryrule") { }

        public override IList<Maintenance> Get(object filter = null, IList<MaintenanceInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectGroups = includeHelper.WhatShouldInclude(MaintenanceInclude.Groups),
                selectHosts = includeHelper.WhatShouldInclude(MaintenanceInclude.Hosts),
                selectTimeperiods = includeHelper.WhatShouldInclude(MaintenanceInclude.TimePeriods),

                filter = filter
            };
            return BaseGet(@params);
        }

        public class MaintenancesidsResult : EntityResultBase
        {
            [JsonProperty("maintenanceids")]
            public override string[] ids { get; set; }
        }
    }

    public enum MaintenanceInclude
    {
        All = 1,
        None = 2,
        Groups = 4,
        Hosts = 8,
        TimePeriods = 16
    }
}
