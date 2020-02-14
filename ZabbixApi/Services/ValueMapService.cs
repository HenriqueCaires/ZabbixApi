using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IValueMapService : ICRUDService<Entities.ValueMap, ValueMapInclude>
    {

    }
    public class ValueMapService : CRUDService<Entities.ValueMap, ValueMapService.ValueMapidsResult, ValueMapInclude>, IValueMapService
    {
        public ValueMapService(IContext context) : base(context, "valuemap") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ValueMapInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            if (@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectMappings", includeHelper.WhatShouldInclude(ValueMapInclude.Mappings));

            @params.AddOrReplace("filter", filter);

            return @params;
        }

        public class ValueMapidsResult : EntityResultBase
        {
            [JsonProperty("valuemapids")]
            public override string[] ids { get; set; }
        }

    }

    public enum ValueMapInclude
    {
        All = 1,
        None = 2,
        Mappings = 4,
    }
}
