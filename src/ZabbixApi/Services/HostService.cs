using SisMon.Zabbix.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;
using ZabbixApi.Entities;

namespace SisMon.Zabbix.Services
{
    public interface IHostService
    {
        IList<Host> Get(object filter = null, IList<HostService.Include> include = null);
        IList<Host> GetByName(string name, IList<HostService.Include> include = null);
        IList<Host> GetByName(List<string> names, IList<HostService.Include> include = null);
        IList<Host> GetById(string id, IList<HostService.Include> include = null);
        IList<Host> GetById(List<string> ids, IList<HostService.Include> include = null);
        IList<string> Create(Host host);
        IList<string> Update(Host host);
        IList<string> Delete(IList<string> ids);
        IList<string> Delete(string id);
        IList<string> Delete(IList<Host> hosts);
        IList<string> Delete(Host host);
    }

    public class HostService : IHostService
    {
        private IContext _context;
        private const string className = "host";

        public HostService(IContext context)
        {
            _context = context;
        }

        public IList<Host> Get(object filter = null, IList<Include> include = null)
        {
            var includeHelper = new IncludeHelper(include == null ? 1 : include.Sum(x => (int)x));
            return _context.SendRequest<Host[]>(
                    new
                    {
                        output = "extend",
                        selectGroups = includeHelper.WhatShouldInclude((int)Include.Groups),
                        selectApplications = includeHelper.WhatShouldInclude((int)Include.Applications),
                        selectDiscoveries = includeHelper.WhatShouldInclude((int)Include.Discoveries),
                        selectDiscoveryRule = includeHelper.WhatShouldInclude((int)Include.DiscoveryRule),
                        selectGraphs = includeHelper.WhatShouldInclude((int)Include.Graphs),
                        selectHostDiscovery = includeHelper.WhatShouldInclude((int)Include.HostDiscovery),
                        selectHttpTests = includeHelper.WhatShouldInclude((int)Include.HttpTests),
                        selectInterfaces = includeHelper.WhatShouldInclude((int)Include.Interfaces),
                        selectInventory = includeHelper.WhatShouldInclude((int)Include.Inventory),
                        selectItems = includeHelper.WhatShouldInclude((int)Include.Items),
                        selectMacros = includeHelper.WhatShouldInclude((int)Include.Macros),
                        selectParentTemplates = includeHelper.WhatShouldInclude((int)Include.ParentTemplates),
                        selectScreens = includeHelper.WhatShouldInclude((int)Include.Screens),
                        selectTriggers = includeHelper.WhatShouldInclude((int)Include.Triggers),
                        filter = filter
                    },
                    className + ".get"
                    );
        }

        public IList<Host> GetByName(string name, IList<Include> include = null)
        {
            return GetByName(
                names: new List<string>() { name },
                include: include
            );
        }

        public IList<Host> GetByName(List<string> names, IList<Include> include = null)
        {
            return Get(
                filter: new
                {
                    host = names
                },
                include: include
            );
        }

        public IList<Host> GetById(string id, IList<Include> include = null)
        {
            return GetById(
                ids: new List<string>() { id },
                include: include
            );
        }

        public IList<Host> GetById(List<string> ids, IList<Include> include = null)
        {
            return Get(
                filter: new
                {
                    hostids = ids
                },
                include: include
            );
        }

        public IList<string> Create(Host host)
        {
            return _context.SendRequest<HostidsResult>(
                    host,
                    className + ".create"
                    ).hostids;
        }

        public IList<string> Update(Host host)
        {
            return _context.SendRequest<HostidsResult>(
                    host,
                    className + ".update"
                    ).hostids;
        }

        public IList<string> Delete(IList<string> ids)
        {
            return _context.SendRequest<HostidsResult>(
                    ids,
                    className + ".update"
                    ).hostids;
        }

        public IList<string> Delete(string id)
        {
            return Delete(new List<string>() { id });
        }

        public IList<string> Delete(IList<Host> hosts)
        {
            return Delete(hosts.Select(x => x.hostid).ToList());
        }

        public IList<string> Delete(Host host)
        {
            return Delete(host.hostid);
        }

        internal class HostidsResult
        {
            public IList<string> hostids { get; set; }
        }

        public enum Include
        {
            All = 1,
            Groups = 2,
            Applications = 4,
            Discoveries = 8,
            DiscoveryRule = 16,
            Graphs = 32,
            HostDiscovery = 64,
            HttpTests = 128,
            Interfaces = 256,
            Inventory = 512,
            Items = 1024,
            Macros = 2048,
            ParentTemplates = 4096,
            Screens = 8192,
            Triggers = 16384
        }
    }
}
