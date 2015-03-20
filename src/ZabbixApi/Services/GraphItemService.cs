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
    public interface IGraphItemService
    {
        IEnumerable<GraphItem> Get(object filter = null, IEnumerable<GraphItemInclude> include = null);
    }

    public class GraphItemService : ServiceBase<GraphItem>, IGraphItemService
    {
        public GraphItemService(IContext context) : base(context, "graphitem") { }

        public IEnumerable<GraphItem> Get(object filter = null, IEnumerable<GraphItemInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectGraphs = includeHelper.WhatShouldInclude(GraphItemInclude.Graphs),

                filter = filter
            };
            return BaseGet(@params);
        }
    }

    public enum GraphItemInclude
    {
        All = 1,
        None = 2,
        Graphs = 4
    }
}
