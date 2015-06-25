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
    public interface IIconMapService : ICRUDService<IconMap, IconMapInclude>
    {

    }

    public class IconMapService : CRUDService<IconMap, IconMapService.IconMapsidsResult, IconMapInclude>, IIconMapService
    {
        public IconMapService(IContext context) : base(context, "iconmap") { }

        public override IEnumerable<IconMap> Get(object filter = null, IEnumerable<IconMapInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectMappings", includeHelper.WhatShouldInclude(IconMapInclude.Mappings));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class IconMapsidsResult : EntityResultBase
        {
            [JsonProperty("iconmapids")]
            public override string[] ids { get; set; }
        }
    }

    public enum IconMapInclude
    {
        All = 1,
        None = 2,
        Mappings = 4,

    }
}
