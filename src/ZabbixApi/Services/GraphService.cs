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
    public interface IGraphService : ICRUDService<Graph, GraphInclude>
    {

    }
    public class GraphService : CRUDService<Graph, GraphService.GraphsidsResult, GraphInclude>, IGraphService
    {
        public GraphService(IContext context) : base(context, "graph") { }

        public override IEnumerable<Graph> Get(object filter = null, IEnumerable<GraphInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddOrReplace("output", "extend");
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(GraphInclude.Groups));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(GraphInclude.Templates));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(GraphInclude.Hosts));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(GraphInclude.Items));
            @params.AddOrReplace("selectGraphItems", includeHelper.WhatShouldInclude(GraphInclude.GraphItems));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(GraphInclude.DiscoveryRule));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class GraphsidsResult : EntityResultBase
        {
            [JsonProperty("graphids")]
            public override string[] ids { get; set; }
        }


    }

    public enum GraphInclude
    {
        All = 1,
        None = 2,
        Groups = 4,
        Templates = 8,
        Hosts = 16,
        Items = 32,
        GraphItems = 64,
        DiscoveryRule = 128
    }
}
