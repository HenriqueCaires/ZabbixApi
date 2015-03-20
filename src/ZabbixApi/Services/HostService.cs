using Newtonsoft.Json;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;
using ZabbixApi.Entities;

namespace ZabbixApi.Services
{
    public interface IHostService : ICRUDService<Host, HostInclude>
    {
        IList<Host> GetByName(string name, IList<HostInclude> include = null);
        IList<Host> GetByName(List<string> names, IList<HostInclude> include = null);
        IList<Host> GetById(string id, IList<HostInclude> include = null);
        IList<Host> GetById(List<string> ids, IList<HostInclude> include = null);
    }

    public class HostService : CRUDService<Host, HostService.HostidsResult, HostInclude>, IHostService
    {
        public HostService(IContext context) : base(context, "host") { }


        public override IList<Host> Get(object filter = null, IList<HostInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            var @params = new
                    {
                        output = "extend",
                        selectGroups = includeHelper.WhatShouldInclude(HostInclude.Groups),
                        selectApplications = includeHelper.WhatShouldInclude(HostInclude.Applications),
                        selectDiscoveries = includeHelper.WhatShouldInclude(HostInclude.Discoveries),
                        selectDiscoveryRule = includeHelper.WhatShouldInclude(HostInclude.DiscoveryRule),
                        selectGraphs = includeHelper.WhatShouldInclude(HostInclude.Graphs),
                        selectHostDiscovery = includeHelper.WhatShouldInclude(HostInclude.HostDiscovery),
                        selectHttpTests = includeHelper.WhatShouldInclude(HostInclude.HttpTests),
                        selectInterfaces = includeHelper.WhatShouldInclude(HostInclude.Interfaces),
                        selectInventory = includeHelper.WhatShouldInclude(HostInclude.Inventory),
                        selectItems = includeHelper.WhatShouldInclude(HostInclude.Items),
                        selectMacros = includeHelper.WhatShouldInclude(HostInclude.Macros),
                        selectParentTemplates = includeHelper.WhatShouldInclude(HostInclude.ParentTemplates),
                        selectScreens = includeHelper.WhatShouldInclude(HostInclude.Screens),
                        selectTriggers = includeHelper.WhatShouldInclude(HostInclude.Triggers),

                        filter = filter
                    };

            return BaseGet(@params);
        }

        public IList<Host> GetByName(string name, IList<HostInclude> include = null)
        {
            return GetByName(
                names: new List<string>() { name },
                include: include
            );
        }

        public IList<Host> GetByName(List<string> names, IList<HostInclude> include = null)
        {
            return Get(
                filter: new
                {
                    host = names
                },
                include: include
            );
        }

        public IList<Host> GetById(string id, IList<HostInclude> include = null)
        {
            return GetById(
                ids: new List<string>() { id },
                include: include
            );
        }

        public IList<Host> GetById(List<string> ids, IList<HostInclude> include = null)
        {
            return Get(
                filter: new
                {
                    hostids = ids
                },
                include: include
            );
        }

        public class HostidsResult : EntityResultBase
        {
            [JsonProperty("hostids")]
            public override string[] ids { get; set; }
        }

        
    }

    public enum HostInclude
    {
        All = 1,
        None = 2,
        Groups = 4,
        Applications = 8,
        Discoveries = 16,
        DiscoveryRule = 32,
        Graphs = 64,
        HostDiscovery = 128,
        HttpTests = 256,
        Interfaces = 512,
        Inventory = 1024,
        Items = 2048,
        Macros = 4096,
        ParentTemplates = 8192,
        Screens = 16384,
        Triggers = 32768
    }
}
