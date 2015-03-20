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

        public override IList<Graph> Get(object filter = null, IList<GraphInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectGroups = includeHelper.WhatShouldInclude(GraphInclude.Groups),
                selectTemplates = includeHelper.WhatShouldInclude(GraphInclude.Templates),
                selectHosts = includeHelper.WhatShouldInclude(GraphInclude.Hosts),
                selectItems = includeHelper.WhatShouldInclude(GraphInclude.Items),
                selectGraphItems = includeHelper.WhatShouldInclude(GraphInclude.GraphItems),
                selectDiscoveryRule = includeHelper.WhatShouldInclude(GraphInclude.DiscoveryRule),

                filter = filter
            };
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
