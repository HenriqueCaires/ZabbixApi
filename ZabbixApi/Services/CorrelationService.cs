using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface ICorrelationService : ICRUDService<Entities.Correlation, CorrelationInclude>
    {

    }
    public class CorrelationService : CRUDService<Entities.Correlation, ActionService.ActionsidsResult, CorrelationInclude>, ICorrelationService
    {
        public CorrelationService(IContext context) : base(context, "correlation") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<CorrelationInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectFilter", includeHelper.WhatShouldInclude(CorrelationInclude.Filters));
            @params.AddOrReplace("selectOperations", includeHelper.WhatShouldInclude(CorrelationInclude.Operations));

            @params.AddOrReplace("filter", filter);

            return @params;
        }

    }
    public enum CorrelationInclude
    {
        All = 1,
        None = 2,
        Filters = 4,
        Operations = 8,
    }
}
