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
    public interface IMapService : ICRUDService<Map, MapInclude>
    {

    }

    public class MapService : CRUDService<Map, MapService.MapsidsResult, MapInclude>, IMapService
    {
        public MapService(IContext context) : base(context, "map") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<MapInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("expandUrls", includeHelper.WhatShouldInclude(MapInclude.ExpandUrls) != null);
            @params.AddOrReplace("selectIconMap", includeHelper.WhatShouldInclude(MapInclude.IconMap));
            @params.AddOrReplace("selectLinks", includeHelper.WhatShouldInclude(MapInclude.Links));
            @params.AddOrReplace("selectSelements", includeHelper.WhatShouldInclude(MapInclude.Selements));
            @params.AddOrReplace("selectUrls", includeHelper.WhatShouldInclude(MapInclude.Urls));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class MapsidsResult : EntityResultBase
        {
            [JsonProperty("sysmapids")]
            public override string[] ids { get; set; }
        }
    }

    public enum MapInclude
    {
        All = 1,
        None = 2,
        ExpandUrls = 4,
        IconMap = 8,
        Links = 16,
        Selements = 32,
        Urls = 64
    }
}
