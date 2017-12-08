using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Helper;
using ZabbixApi;
using ZabbixApi.Entities;

namespace ZabbixApi.Services
{
    public interface IHostInterfaceService : ICRUDService<HostInterface, HostInterfaceInclude>
    {

    }

    public class HostInterfaceService : CRUDService<HostInterface, HostInterfaceService.HostInterfacesidsResult, HostInterfaceInclude>, IHostInterfaceService
    {
        public HostInterfaceService(IContext context) : base(context, "hostinterface") { }

        public override IEnumerable<HostInterface> Get(object filter = null, IEnumerable<HostInterfaceInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectItems", includeHelper.WhatShouldInclude(HostInterfaceInclude.Items));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(HostInterfaceInclude.Hosts));

            @params.AddOrReplace("filter", filter);
            
            return BaseGet(@params);
        }

        public class HostInterfacesidsResult : EntityResultBase
        {
            [JsonProperty("interfaceids")]
            public override string[] ids { get; set; }
        }
    }

    public enum HostInterfaceInclude
    {
        All = 1,
        None = 2,
        Items = 4,
        Hosts = 8
    }

}
