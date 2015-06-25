using ZabbixApi.Entities;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;

namespace ZabbixApi.Services
{
    public interface ICRUDService<T, Y>
        where T : EntityBase
        where Y : struct, IConvertible
    {
        IEnumerable<T> Get(object filter = null, IEnumerable<Y> include = null, Dictionary<string, object> @params = null);
        IEnumerable<string> Create(T entity);
        IEnumerable<string> Update(T entity);
        IEnumerable<string> Delete(IEnumerable<string> ids);
        IEnumerable<string> Delete(string id);
        IEnumerable<string> Delete(IEnumerable<T> entities);
        IEnumerable<string> Delete(T entity);
    }

    public abstract class CRUDService<T, X, Y> : ServiceBase<T>, ICRUDService<T, Y>
        where T : EntityBase
        where X : EntityResultBase
        where Y : struct, IConvertible
    {
        public CRUDService(IContext context, string className) : base(context, className) { }

        public abstract IEnumerable<T> Get(object filter = null, IEnumerable<Y> include = null, Dictionary<string, object> @params = null);

        public IEnumerable<string> Create(T entity)
        {
            return _context.SendRequest<X>(
                    entity,
                    _className + ".create"
                    ).ids;
        }

        public IEnumerable<string> Update(T entity)
        {
            return _context.SendRequest<X>(
                    entity,
                    _className + ".update"
                    ).ids;
        }

        public IEnumerable<string> Delete(IEnumerable<string> ids)
        {
            return _context.SendRequest<X>(
                    ids,
                    _className + ".delete"
                    ).ids;
        }

        public IEnumerable<string> Delete(string id)
        {
            return Delete(new List<string>() { id });
        }

        public IEnumerable<string> Delete(IEnumerable<T> entities)
        {
            return Delete(entities.Select(x => x.Id));
        }

        public IEnumerable<string> Delete(T entity)
        {
            return Delete(entity.Id);
        }
    }
}
