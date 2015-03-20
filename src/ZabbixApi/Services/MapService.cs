using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zabbix.Entities;
using Zabbix.Helper;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface IMapService : ICRUDService<Map, MapInclude>
    {

    }

    public class MapService : CRUDService<Map, MapService.MapsidsResult, MapInclude>, IMapService
    {
        public MapService(IContext context) : base(context, "map") { }

        public override IList<Map> Get(object filter = null, IList<MapInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                expandUrls = includeHelper.WhatShouldInclude(MapInclude.ExpandUrls) != null,
                selectIconMap = includeHelper.WhatShouldInclude(MapInclude.IconMap),
                selectLinks = includeHelper.WhatShouldInclude(MapInclude.Links),
                selectSelements = includeHelper.WhatShouldInclude(MapInclude.Selements),
                selectUrls = includeHelper.WhatShouldInclude(MapInclude.Urls),

                filter = filter
            };
            return BaseGet(@params);
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
