using Newtonsoft.Json;
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
    public interface IMaintenanceService : ICRUDService<Maintenance, MaintenanceInclude>
    {

    }

    public class MaintenanceService : CRUDService<Maintenance, MaintenanceService.MaintenancesidsResult, MaintenanceInclude>, IMaintenanceService
    {
        public MaintenanceService(IContext context) : base(context, "maintenance") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<MaintenanceInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(MaintenanceInclude.Groups));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(MaintenanceInclude.Hosts));
            @params.AddOrReplace("selectTimeperiods", includeHelper.WhatShouldInclude(MaintenanceInclude.TimePeriods));

            @params.AddOrReplace("filter", filter);
            
            return @params;
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
