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
    public interface IProxyService : ICRUDService<Proxy, ProxyInclude>
    {

    }

    public class ProxyService : CRUDService<Proxy, ProxyService.ProxysidsResult, ProxyInclude>, IProxyService
    {
        public ProxyService(IContext context) : base(context, "proxy") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<ProxyInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(ProxyInclude.Hosts));
            @params.AddOrReplace("selectInterface", includeHelper.WhatShouldInclude(ProxyInclude.Interface));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class ProxysidsResult : EntityResultBase
        {
            [JsonProperty("proxyids")]
            public override string[] ids { get; set; }
        }
    }

    public enum ProxyInclude
    {
        All = 1,
        None = 2,
        Hosts = 4,
        Interface = 8
    }
}
