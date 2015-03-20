using ZabbixApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;

namespace ZabbixApi.Services
{
    public class ServiceBase<T> where T : EntityBase
    {
        protected IContext _context;
        protected readonly string _className;

        protected ServiceBase(IContext context, string className)
        {
            _context = context;
            _className = className;
        }

        public IEnumerable<T> BaseGet(object @params)
        {
            return _context.SendRequest<T[]>(
                    @params,
                    _className + ".get"
                    );
        }
    }
}
