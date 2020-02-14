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
    public interface ITemplateService : ICRUDService<Template, TemplateInclude>
    {

    }

    public class TemplateService : CRUDService<Template, TemplateService.TemplatesidsResult, TemplateInclude>, ITemplateService
    {
        public TemplateService(IContext context) : base(context, "template") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TemplateInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(TemplateInclude.Groups));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(TemplateInclude.Hosts));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(TemplateInclude.Templates));
            @params.AddOrReplace("selectParentTemplates", includeHelper.WhatShouldInclude(TemplateInclude.ParentTemplates));
            @params.AddOrReplace("selectHttpTests", includeHelper.WhatShouldInclude(TemplateInclude.HttpTests));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(TemplateInclude.Items));
            @params.AddOrReplace("selectDiscoveries", includeHelper.WhatShouldInclude(TemplateInclude.Discoveries));
            @params.AddOrReplace("selectTriggers", includeHelper.WhatShouldInclude(TemplateInclude.Triggers));
            @params.AddOrReplace("selectGraphs", includeHelper.WhatShouldInclude(TemplateInclude.Graphs));
            @params.AddOrReplace("selectApplications", includeHelper.WhatShouldInclude(TemplateInclude.Applications));
            @params.AddOrReplace("selectMacros", includeHelper.WhatShouldInclude(TemplateInclude.Macros));
            @params.AddOrReplace("selectScreens", includeHelper.WhatShouldInclude(TemplateInclude.Screens));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class TemplatesidsResult : EntityResultBase
        {
            [JsonProperty("templateids")]
            public override string[] ids { get; set; }
        }
    }

    public enum TemplateInclude
    {
        All = 1,
        None = 2,
        Groups = 4,
        Hosts = 8,
        Templates = 16,
        ParentTemplates = 32,
        HttpTests = 64,
        Items = 128,
        Discoveries = 256,
        Triggers = 512,
        Graphs = 1024,
        Applications = 2048,
        Macros = 4096,
        Screens = 8192
    }
}
