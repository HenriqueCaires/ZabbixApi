using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;

namespace ZabbixApi.Services
{
    public interface IActionService : ICRUDService<Entities.Action, ActionInclude>
    {

    }
    public class ActionService : CRUDService<Entities.Action, ActionService.ActionsidsResult, ActionInclude>, IActionService
    {
        public ActionService(IContext context) : base(context, "action") { }

        public override IEnumerable<Entities.Action> Get(object filter = null, IEnumerable<ActionInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectConditions", includeHelper.WhatShouldInclude(ActionInclude.Conditions));
            @params.AddOrReplace("selectOperations", includeHelper.WhatShouldInclude(ActionInclude.Operations));

            @params.AddOrReplace("filter", filter);
                    
            return BaseGet(@params);
        }

        public class ActionsidsResult : EntityResultBase
        {
            [JsonProperty("actionids")]
            public override string[] ids { get; set; }
        }

        
    }

    public enum ActionInclude
    {
        All = 1,
        None = 2,
        Conditions = 4,
        Operations = 8
    }
}
