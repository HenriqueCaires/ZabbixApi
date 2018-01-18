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

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ScriptInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectGroups", includeHelper.WhatShouldInclude(ScriptInclude.Groups));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(ScriptInclude.Hosts));

            @params.AddOrReplace("filter", filter);
            
            return @params;
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
