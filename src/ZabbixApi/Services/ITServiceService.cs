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
    public interface IITServiceService : ICRUDService<ITService, ITServiceInclude>
    {

    }

    public class ITServiceService : CRUDService<ITService, ITServiceService.ITServicesidsResult, ITServiceInclude>, IITServiceService
    {
        public ITServiceService(IContext context) : base(context, "ITService") { }

        public override IEnumerable<ITService> Get(object filter = null, IEnumerable<ITServiceInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectParent", includeHelper.WhatShouldInclude(ITServiceInclude.Parent));
            @params.AddOrReplace("selectDependencies", includeHelper.WhatShouldInclude(ITServiceInclude.Dependencies));
            @params.AddOrReplace("selectParentDependencies", includeHelper.WhatShouldInclude(ITServiceInclude.ParentDependencies));
            @params.AddOrReplace("selectTimes", includeHelper.WhatShouldInclude(ITServiceInclude.Times));
            @params.AddOrReplace("selectAlarms", includeHelper.WhatShouldInclude(ITServiceInclude.Alarms));
            @params.AddOrReplace("selectTrigger", includeHelper.WhatShouldInclude(ITServiceInclude.Trigger));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class ITServicesidsResult : EntityResultBase
        {
            [JsonProperty("serviceids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ITServiceInclude
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
