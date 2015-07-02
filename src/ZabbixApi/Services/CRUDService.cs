using ZabbixApi.Entities;
using ZabbixApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi;
using Newtonsoft.Json;

namespace ZabbixApi.Services
{
    public interface ICRUDService<T, Y>
        where T : EntityBase
        where Y : struct, IConvertible
    {
        IEnumerable<T> Get(object filter = null, IEnumerable<Y> include = null, Dictionary<string, object> @params = null);
        IEnumerable<string> Create(IEnumerable<T> entity);
        string Create(T entity);
        IEnumerable<string> Update(IEnumerable<T> entity);
        string Update(T entity);
        IEnumerable<string> Delete(IEnumerable<string> ids);
        string Delete(string id);
        IEnumerable<string> Delete(IEnumerable<T> entities);
        string Delete(T entity);
        IEnumerable<T> GetById(IEnumerable<string> ids, IEnumerable<Y> include = null);
        T GetById(string id, IEnumerable<Y> include = null);
        IEnumerable<T> GetById(IEnumerable<long> ids, IEnumerable<Y> include = null);
        T GetById(long id, IEnumerable<Y> include = null);
        IEnumerable<string> CreateOrUpdate(IEnumerable<T> entities);
        string CreateOrUpdate(T entity);
    }

    public abstract class CRUDService<T, X, Y> : ServiceBase<T>, ICRUDService<T, Y>
        where T : EntityBase
        where X : EntityResultBase
        where Y : struct, IConvertible
    {
        private string IdsAttribute
        {
            get
            {
                return ((JsonPropertyAttribute)typeof(T).GetProperty("Id").GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault()).PropertyName;
            }
        }

        public CRUDService(IContext context, string className) : base(context, className) { }

        public abstract IEnumerable<T> Get(object filter = null, IEnumerable<Y> include = null, Dictionary<string, object> @params = null);

        public IEnumerable<T> Get(Y include, object filter = null, Dictionary<string, object> @params = null)
        {
            return Get(filter: filter, include: new List<Y>() { include }, @params: @params);
        }

        public IEnumerable<T> GetById(IEnumerable<string> ids, IEnumerable<Y> include = null)
        {
            var filter = new Dictionary<string, object>();
            filter.Add(IdsAttribute, ids);
            return Get(
                filter: filter,
                include: include
            );
        }

        public T GetById(string id, IEnumerable<Y> include = null)
        {
            return GetById(
                ids: new List<string>() { id },
                include: include
            ).FirstOrDefault();
        }

        public IEnumerable<T> GetById(IEnumerable<long> ids, IEnumerable<Y> include = null)
        {
            return GetById(
                ids: ids.Select(x => x.ToString()),
                include: include
            );
        }

        public T GetById(long id, IEnumerable<Y> include = null)
        {
            return GetById(
                ids: new List<long>() { id },
                include: include
            ).FirstOrDefault();
        }

        public IEnumerable<T> GetByPropety(string name, IEnumerable<object> values, IEnumerable<Y> include = null)
        {
            var filter = new Dictionary<string, object>();
            filter.Add(name, values.Select(x => x.ToString()));
            return Get(
                filter: filter,
                include: include
            );
        }

        public T GetByPropety(string name, object value, IEnumerable<Y> include = null)
        {
            return GetByPropety(
                name: name,
                values: new List<string>() { value.ToString() },
                include: include
            ).FirstOrDefault();
        }

        public IEnumerable<string> Create(IEnumerable<T> entities)
        {
            return _context.SendRequest<X>(
                    entities,
                    _className + ".create"
                    ).ids;
        }

        public string Create(T entity)
        {
            return Create(new List<T>() { entity }).FirstOrDefault();
        }

        public IEnumerable<string> Update(IEnumerable<T> entity)
        {
            return _context.SendRequest<X>(
                    entity,
                    _className + ".update"
                    ).ids;
        }

        public string Update(T entity)
        {
            return Update(new List<T>() { entity }).FirstOrDefault();
        }

        public IEnumerable<string> CreateOrUpdate(IEnumerable<T> entities)
        {
            var objectsToCreate = entities.Where(x => x.Id == null);
            var objectsToUpdate = entities.Where(x => x.Id != null);

            var result = new List<string>();

            if (objectsToCreate.Any())
                result.AddRange(Create(objectsToCreate));

            if (objectsToUpdate.Any())
                result.AddRange(Update(objectsToUpdate));

            return result;

        }

        public string CreateOrUpdate(T entity)
        {
            if (entity.Id == null)
                return Create(new List<T>() { entity }).FirstOrDefault();
            else
                return Update(new List<T>() { entity }).FirstOrDefault();
        }

        public IEnumerable<string> Delete(IEnumerable<string> ids)
        {
            return _context.SendRequest<X>(
                    ids,
                    _className + ".delete"
                    ).ids;
        }

        public string Delete(string id)
        {
            return Delete(new List<string>() { id }).FirstOrDefault();
        }

        public IEnumerable<string> Delete(IEnumerable<T> entities)
        {
            return Delete(entities.Select(x => x.Id));
        }

        public string Delete(T entity)
        {
            return Delete(entity.Id);
        }
    }
}
