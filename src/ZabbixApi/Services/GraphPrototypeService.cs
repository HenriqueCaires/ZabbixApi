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

        public override IList<GraphPrototype> Get(object filter = null, IList<GraphPrototypeInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectDiscoveryRule = includeHelper.WhatShouldInclude(GraphPrototypeInclude.DiscoveryRule),
                selectGraphItems = includeHelper.WhatShouldInclude(GraphPrototypeInclude.GraphItems),
                selectGroups = includeHelper.WhatShouldInclude(GraphPrototypeInclude.Groups),
                selectHosts = includeHelper.WhatShouldInclude(GraphPrototypeInclude.Hosts),
                selectItems = includeHelper.WhatShouldInclude(GraphPrototypeInclude.Items),
                selectTemplates = includeHelper.WhatShouldInclude(GraphPrototypeInclude.Templates),
                

                filter = filter
            };
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
