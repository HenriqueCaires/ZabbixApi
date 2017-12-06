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
    public interface IGraphPrototypeService : ICRUDService<GraphPrototype, GraphPrototypeInclude>
    {

    }

    public class GraphPrototypeService : CRUDService<GraphPrototype, GraphPrototypeService.GraphPrototypesidsResult, GraphPrototypeInclude>, IGraphPrototypeService
    {
        public GraphPrototypeService(IContext context) : base(context, "graphprototype") { }

        public override IEnumerable<GraphPrototype> Get(object filter = null, IEnumerable<GraphPrototypeInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(GraphPrototypeInclude.DiscoveryRule));
            @params.AddOrReplace("selectGraphItems", includeHelper.WhatShouldInclude(GraphPrototypeInclude.GraphItems));
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(GraphPrototypeInclude.Groups));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(GraphPrototypeInclude.Hosts));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(GraphPrototypeInclude.Items));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(GraphPrototypeInclude.Templates));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class GraphPrototypesidsResult : EntityResultBase
        {
            [JsonProperty("graphids")]
            public override string[] ids { get; set; }
        }
    }

    public enum GraphPrototypeInclude
    {
        All = 1,
        None = 2,
        DiscoveryRule = 4,
        GraphItems = 8,
        Groups = 16,
        Hosts = 32,
        Items = 64,
        Templates = 128
    }
}
