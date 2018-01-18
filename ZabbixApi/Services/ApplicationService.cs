using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ZabbixApi.Entities;
using ZabbixApi.Helper;


namespace ZabbixApi.Services
{
    public interface IApplicationService : ICRUDService<Application, ApplicationInclude>
    {

    }
    
    public class ApplicationService : CRUDService<Application, ApplicationService.ApplicationsidsResult, ApplicationInclude>, IApplicationService
    {
        public ApplicationService(IContext context) : base(context, "application") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ApplicationInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(ApplicationInclude.Hosts));
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(ApplicationInclude.Items));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class ApplicationsidsResult : EntityResultBase
        {
            [JsonProperty("applicationids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ApplicationInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        Items = 8
    }
}
