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

        public override IList<ITService> Get(object filter = null, IList<ITServiceInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectParent = includeHelper.WhatShouldInclude(ITServiceInclude.Parent),
                selectDependencies = includeHelper.WhatShouldInclude(ITServiceInclude.Dependencies),
                selectParentDependencies = includeHelper.WhatShouldInclude(ITServiceInclude.ParentDependencies),
                selectTimes = includeHelper.WhatShouldInclude(ITServiceInclude.Times),
                selectAlarms = includeHelper.WhatShouldInclude(ITServiceInclude.Alarms),
                selectTrigger = includeHelper.WhatShouldInclude(ITServiceInclude.Trigger),

                filter = filter
            };
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
