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

        public override IEnumerable<Template> Get(object filter = null, IEnumerable<TemplateInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectGroups = includeHelper.WhatShouldInclude(TemplateInclude.Groups),
                selectHosts = includeHelper.WhatShouldInclude(TemplateInclude.Hosts),
                selectTemplates = includeHelper.WhatShouldInclude(TemplateInclude.Templates),
                selectParentTemplates = includeHelper.WhatShouldInclude(TemplateInclude.ParentTemplates),
                selectHttpTests = includeHelper.WhatShouldInclude(TemplateInclude.HttpTests),
                selectItems = includeHelper.WhatShouldInclude(TemplateInclude.Items),
                selectDiscoveries = includeHelper.WhatShouldInclude(TemplateInclude.Discoveries),
                selectTriggers = includeHelper.WhatShouldInclude(TemplateInclude.Triggers),
                selectGraphs = includeHelper.WhatShouldInclude(TemplateInclude.Graphs),
                selectApplications = includeHelper.WhatShouldInclude(TemplateInclude.Applications),
                selectMacros = includeHelper.WhatShouldInclude(TemplateInclude.Macros),
                selectScreens = includeHelper.WhatShouldInclude(TemplateInclude.Screens),

                filter = filter
            };
            return BaseGet(@params);
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
