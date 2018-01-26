using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZabbixApi.Helper;
using ZabbixApi.Entities;

namespace ZabbixApi.Services
{
    public interface IHostGroupService : ICRUDService<HostGroup, HostGroupInclude>
    {
        HostGroup GetByName(string name, IList<HostGroupInclude> include = null);
        IEnumerable<HostGroup> GetByName(List<string> names, IList<HostGroupInclude> include = null);
        HostGroup GetByName(string name, HostGroupInclude include);
        IEnumerable<HostGroup> GetByName(List<string> names, HostGroupInclude include);

        Task<HostGroup> GetByNameAsync(string name, IList<HostGroupInclude> include = null);
        Task<IReadOnlyList<HostGroup>> GetByNameAsync(List<string> names, IList<HostGroupInclude> include = null);
        Task<HostGroup> GetByNameAsync(string name, HostGroupInclude include);
        Task<IReadOnlyList<HostGroup>> GetByNameAsync(List<string> names, HostGroupInclude include);
    }

    public class HostGroupService : CRUDService<HostGroup, HostGroupService.HostGroupsidsResult, HostGroupInclude>, IHostGroupService
    {
        public HostGroupService(IContext context) : base(context, "hostgroup") { }

        protected override Dictionary<string, object> BuildParams(object filter = null, IEnumerable<HostGroupInclude> include = null, Dictionary<string, object> @params = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            if(@params == null)
                @params = new Dictionary<string, object>();

            @params.AddIfNotExist("output", "extend");
            @params.AddOrReplace("selectDiscoveryRule", includeHelper.WhatShouldInclude(HostGroupInclude.DiscoveryRule));
            @params.AddOrReplace("selectGroupDiscovery", includeHelper.WhatShouldInclude(HostGroupInclude.GroupDiscovery));
            @params.AddOrReplace("selectHosts", includeHelper.WhatShouldInclude(HostGroupInclude.Hosts));
            @params.AddOrReplace("selectTemplates", includeHelper.WhatShouldInclude(HostGroupInclude.Templates));

            @params.AddOrReplace("filter", filter);
            
            return @params;
        }

        public class HostGroupsidsResult : EntityResultBase
        {
            [JsonProperty("groupids")]
            public override string[] ids { get; set; }
        }

        public HostGroup GetByName(string name, IList<HostGroupInclude> include = null)
        {
            return GetByName(
                names: new List<string> { name },
                include: include
            ).FirstOrDefault();
        }

        public async Task<HostGroup> GetByNameAsync(string name, IList<HostGroupInclude> include = null)
        {
            return (await GetByNameAsync(
                names: new List<string> { name },
                include: include
            )).FirstOrDefault();
        }

        public IEnumerable<HostGroup> GetByName(List<string> names, IList<HostGroupInclude> include = null)
        {
            return Get(
                filter: new
                {
                    name = names
                },
                include: include
            );
        }

        public async Task<IReadOnlyList<HostGroup>> GetByNameAsync(List<string> names, IList<HostGroupInclude> include = null)
        {
            return await GetAsync(
                filter: new
                {
                    name = names
                },
                include: include
            );
        }

        public HostGroup GetByName(string name, HostGroupInclude include)
        {
            return GetByName(
                names: new List<string> { name },
                include: include
            ).FirstOrDefault();
        }

        public async Task<HostGroup> GetByNameAsync(string name, HostGroupInclude include)
        {
            return (await GetByNameAsync(
                names: new List<string> { name },
                include: include
            )).FirstOrDefault();
        }

        public IEnumerable<HostGroup> GetByName(List<string> names, HostGroupInclude include)
        {
            return Get(
                filter: new
                {
                    name = names
                },
                include: include
            );
        }

        public async Task<IReadOnlyList<HostGroup>> GetByNameAsync(List<string> names, HostGroupInclude include)
        {
            return await GetAsync(
                filter: new
                {
                    name = names
                },
                include: include
            );
        }
    }

    public enum HostGroupInclude
    {
        All = 1,
        None = 2,
        DiscoveryRule = 4,
        GroupDiscovery = 8,
        Hosts = 16,
        Templates = 32
    }
}
