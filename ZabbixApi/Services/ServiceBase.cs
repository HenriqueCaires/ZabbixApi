using ZabbixApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZabbixApi.Services
{
    public abstract class ServiceBase<TEntity, TInclude> where TEntity : EntityBase
    {
        protected IContext _context;
        protected readonly string _className;

        protected ServiceBase(IContext context, string className)
        {
            _context = context;
            _className = className;
        }

        protected abstract Dictionary<string, object> BuildParams(object filter = null, IEnumerable<TInclude> include = null, Dictionary<string, object> @params = null);

        public IEnumerable<TEntity> Get(object filter = null, IEnumerable<TInclude> include = null, Dictionary<string, object> @params = null)
        {
            return BaseGet(BuildParams(filter, include, @params));
        }

        public Task<IReadOnlyList<TEntity>> GetAsync(object filter = null, IEnumerable<TInclude> include = null, Dictionary<string, object> @params = null)
        {
            return BaseGetAsync(BuildParams(filter, include, @params));
        }

        protected IEnumerable<TEntity> BaseGet(object @params)
        {
            return _context.SendRequest<TEntity[]>(@params, _className + ".get");
        }

        protected async Task<IReadOnlyList<TEntity>> BaseGetAsync(object @params)
        {
            return await _context.SendRequestAsync<TEntity[]>(@params, _className + ".get");
        }
    }
}
