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
    public interface IServiceService : ICRUDService<Service, ServiceInclude>
    {

    }

    public class ServiceService : CRUDService<Service, ServiceService.ServicesidsResult, ServiceInclude>, IServiceService
    {
        public ServiceService(IContext context) : base(context, "Service") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ServiceInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectParent", includeHelper.WhatShouldInclude(ServiceInclude.Parent));
            @params.AddOrReplace("selectDependencies", includeHelper.WhatShouldInclude(ServiceInclude.Dependencies));
            @params.AddOrReplace("selectParentDependencies", includeHelper.WhatShouldInclude(ServiceInclude.ParentDependencies));
            @params.AddOrReplace("selectTimes", includeHelper.WhatShouldInclude(ServiceInclude.Times));
            @params.AddOrReplace("selectAlarms", includeHelper.WhatShouldInclude(ServiceInclude.Alarms));
            @params.AddOrReplace("selectTrigger", includeHelper.WhatShouldInclude(ServiceInclude.Trigger));

            @params.AddOrReplace("filter", filter);

            return @params;
        }

        public class ServicesidsResult : EntityResultBase
        {
            [JsonProperty("serviceids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ServiceInclude
    {
        All = 1,
        None = 2,
        Parent = 4,
        Dependencies = 8,
        ParentDependencies = 16,
        Times = 32,
        Alarms = 64,
        Trigger = 128
    }
}