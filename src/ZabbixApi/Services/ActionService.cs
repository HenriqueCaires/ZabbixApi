using Newtonsoft.Json;
using Zabbix.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface IActionService : ICRUDService<Entities.Action, ActionInclude>
    {

    }
    public class ActionService : CRUDService<Entities.Action, ActionService.ActionsidsResult, ActionInclude>, IActionService
    {
        public ActionService(IContext context) : base(context, "action") { }

        public override IList<Entities.Action> Get(object filter = null, IList<ActionInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
                    {
                        output = "extend",
                        selectConditions = includeHelper.WhatShouldInclude((int)ActionInclude.Conditions),
                        selectOperations = includeHelper.WhatShouldInclude((int)ActionInclude.Operations),

                        filter = filter
                    };
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
