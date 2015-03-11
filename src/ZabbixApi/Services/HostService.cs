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
        IList<Host> Get(object filter = null, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend");
        IList<Host> GetByName(string name, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend");
        IList<Host> GetByName(List<string> names, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend");
        IList<Host> GetById(string id, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend");
        IList<Host> GetById(List<string> ids, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend");
    }

    public class HostService : IHostService
    {
        private IContext _context;
        private const string className = "host";

        public HostService(IContext context)
        {
            _context = context;
        }

        public IList<Host> Get(object filter = null, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend")
        {
            return _context.SendRequest<Host[]>(
                    new
                    {
                        output = output,
                        selectInterfaces = selectInterfaces,
                        selectGroups = selectGroups,
                        filter = filter
                    },
                    className + ".get"
                    );
        }

        public IList<Host> GetByName(string name, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend")
        {
            return GetByName(
                names: new List<string>() { name },
                output: output,
                selectInterfaces: selectInterfaces,
                selectGroups: selectGroups
            );
        }

        public IList<Host> GetByName(List<string> names, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend")
        {
            return Get(
                filter: new
                {
                    host = names
                },
                output: output,
                selectInterfaces: selectInterfaces,
                selectGroups: selectGroups
            );
        }

        public IList<Host> GetById(string id, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend")
        {
            return GetById(
                ids: new List<string>() { id },
                output: output,
                selectInterfaces: selectInterfaces,
                selectGroups: selectGroups
            );
        }

        public IList<Host> GetById(List<string> ids, string output = "extend", string selectInterfaces = "extend", string selectGroups = "extend")
        {
            return Get(
                filter: new
                {
                    hostids = ids
                },
                output: output,
                selectInterfaces: selectInterfaces,
                selectGroups: selectGroups
            );
        }

        
    }
}
