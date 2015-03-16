using Zabbix.Entities;
using Zabbix.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;

namespace Zabbix.Services
{
    public interface ICRUDService<T, Y>
        where T : EntityBase
        where Y : struct, IConvertible
    {
        IList<T> Get(object filter = null, IList<Y> include = null);
        IList<string> Create(T entity);
        IList<string> Update(T entity);
        IList<string> Delete(IList<string> ids);
        IList<string> Delete(string id);
        IList<string> Delete(IList<T> entities);
        IList<string> Delete(T entity);
    }

    public abstract class CRUDService<T, X, Y> : ServiceBase<T>, ICRUDService<T, Y>
        where T : EntityBase
        where X : EntityResultBase
        where Y : struct, IConvertible
    {
        public CRUDService(IContext context, string className) : base(context, className) { }

        public abstract IList<T> Get(object filter = null, IList<Y> include = null);

        public IList<string> Create(T entity)
        {
            return _context.SendRequest<X>(
                    entity,
                    _className + ".create"
                    ).ids;
        }

        public IList<string> Update(T entity)
        {
            return _context.SendRequest<X>(
                    entity,
                    _className + ".update"
                    ).ids;
        }

        public IList<string> Delete(IList<string> ids)
        {
            return _context.SendRequest<X>(
                    ids,
                    _className + ".delete"
                    ).ids;
        }

        public IList<string> Delete(string id)
        {
            return Delete(new List<string>() { id });
        }

        public IList<string> Delete(IList<T> entities)
        {
            return Delete(entities.Select(x => x.Id).ToList());
        }

        public IList<string> Delete(T entity)
        {
            return Delete(entity.Id);
        }
    }
}
