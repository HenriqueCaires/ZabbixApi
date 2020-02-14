﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface IHostService : ICRUDService<Host, HostInclude>
    {
        Host GetByName(string name, IList<HostInclude> include = null);
        IEnumerable<Host> GetByName(List<string> names, IList<HostInclude> include = null);

        Task<Host> GetByNameAsync(string name, IList<HostInclude> include = null);
        Task<IReadOnlyList<Host>> GetByNameAsync(List<string> names, IList<HostInclude> include = null);
    }

    public class HostService : CRUDService<Host, HostService.HostidsResult, HostInclude>, IHostService
    {
        public HostService(IContext context) : base(context, "host") { }


        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<HostInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));

            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(HostInclude.Groups));
            @params.AddOrReplace("selectApplications", includeHelper.WhatShouldInclude(HostInclude.Applications));
            @params.AddOrReplace("selectDiscoveries", includeHelper.WhatShouldInclude(HostInclude.Discoveries));
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(HostInclude.DiscoveryRule));
            @params.AddOrReplace("selectGraphs", includeHelper.WhatShouldInclude(HostInclude.Graphs));
            @params.AddOrReplace("selectHostDiscovery", includeHelper.WhatShouldInclude(HostInclude.HostDiscovery));
            @params.AddOrReplace("selectHttpTests", includeHelper.WhatShouldInclude(HostInclude.HttpTests));
            @params.AddOrReplace("selectInterfaces", includeHelper.WhatShouldInclude(HostInclude.Interfaces));
            @params.AddOrReplace("selectInventory", includeHelper.WhatShouldInclude(HostInclude.Inventory));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(HostInclude.Items));
            @params.AddOrReplace("selectMacros", includeHelper.WhatShouldInclude(HostInclude.Macros));
            @params.AddOrReplace("selectParentTemplates", includeHelper.WhatShouldInclude(HostInclude.ParentTemplates));
            @params.AddOrReplace("selectScreens", includeHelper.WhatShouldInclude(HostInclude.Screens));
            @params.AddOrReplace("selectTriggers", includeHelper.WhatShouldInclude(HostInclude.Triggers));

            @params.AddOrReplace("filter", filter);
            
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() };
            var z = JsonConvert.SerializeObject(@params, settings);

            return @params;
        }

        public Host GetByName(string name, IList<HostInclude> include = null)
        {
            return GetByProperty("host", name, include);
        }

        public async Task<Host> GetByNameAsync(string name, IList<HostInclude> include = null)
        {
            return await GetByPropertyAsync("host", name, include);
        }

        public IEnumerable<Host> GetByName(List<string> names, IList<HostInclude> include = null)
        {
            return GetByProperty("host", names, include);
        }

        public async Task<IReadOnlyList<Host>> GetByNameAsync(List<string> names, IList<HostInclude> include = null)
        {
            return await GetByPropertyAsync("host", names, include);
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
