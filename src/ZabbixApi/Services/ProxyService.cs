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

        public override IEnumerable<Proxy> Get(object filter = null, IEnumerable<ProxyInclude> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            var @params = new
            {
                output = "extend",
                selectHosts = includeHelper.WhatShouldInclude(ProxyInclude.Hosts),
                selectInterface = includeHelper.WhatShouldInclude(ProxyInclude.Interface),

                filter = filter
            };
            return BaseGet(@params);
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
