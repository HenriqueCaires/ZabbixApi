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
    public interface IScriptService : ICRUDService<Script, ScriptInclude>
    {

    }

    public class ScriptService : CRUDService<Script, ScriptService.ScriptsidsResult, ScriptInclude>, IScriptService
    {
        public ScriptService(IContext context) : base(context, "script") { }

        public override IEnumerable<Script> Get(object filter = null, IEnumerable<ScriptInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectGroups = includeHelper.WhatShouldInclude(ScriptInclude.Groups),
                selectHosts = includeHelper.WhatShouldInclude(ScriptInclude.Hosts),

                filter = filter
            };
            return BaseGet(@params);
        }

        public class ScriptsidsResult : EntityResultBase
        {
            [JsonProperty("scriptids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ScriptInclude
    {
        All = 1,
        None = 2,
        Groups = 4,
        Hosts = 8
    }
}
