using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZabbixApi.Entities;
using ZabbixApi.Helper;

namespace ZabbixApi.Services
{
    public interface ICRUDService<TEntity, TInclude>
        where TEntity : EntityBase
        where TInclude : struct, IConvertible
    {
        IEnumerable<TEntity> Get(object filter = null, IEnumerable<TInclude> include = null, Dictionary<string, object> @params = null);
        IEnumerable<string> Create(IEnumerable<TEntity> entity);
        string Create(TEntity entity);
        IEnumerable<string> Update(IEnumerable<TEntity> entity);
        string Update(TEntity entity);
        IEnumerable<string> Delete(IEnumerable<string> ids);
        string Delete(string id);
        IEnumerable<string> Delete(IEnumerable<TEntity> entities);
        string Delete(TEntity entity);
        IEnumerable<TEntity> GetById(IEnumerable<string> ids, IEnumerable<TInclude> include = null);
        TEntity GetById(string id, IEnumerable<TInclude> include = null);
        IEnumerable<TEntity> GetById(IEnumerable<long> ids, IEnumerable<TInclude> include = null);
        TEntity GetById(long id, IEnumerable<TInclude> include = null);
        IEnumerable<string> CreateOrUpdate(IEnumerable<TEntity> entities);
        string CreateOrUpdate(TEntity entity);

        Task<IReadOnlyList<TEntity>> GetAsync(object filter = null, IEnumerable<TInclude> include = null, Dictionary<string, object> @params = null);
        Task<IReadOnlyList<string>> CreateAsync(IEnumerable<TEntity> entity);
        Task<string> CreateAsync(TEntity entity);
        Task<IReadOnlyList<string>> UpdateAsync(IEnumerable<TEntity> entity);
        Task<string> UpdateAsync(TEntity entity);
        Task<IReadOnlyList<string>> DeleteAsync(IEnumerable<string> ids);
        Task<string> DeleteAsync(string id);
        Task<IReadOnlyList<string>> DeleteAsync(IEnumerable<TEntity> entities);
        Task<string> DeleteAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetByIdAsync(IEnumerable<string> ids, IEnumerable<TInclude> include = null);
        Task<TEntity> GetByIdAsync(string id, IEnumerable<TInclude> include = null);
        Task<IEnumerable<string>> CreateOrUpdateAsync(IEnumerable<TEntity> entities);
        Task<string> CreateOrUpdateAsync(TEntity entity);
    }

    public abstract class CRUDService<TEntity, TEntityResult, TInclude> : ServiceBase<TEntity, TInclude>, ICRUDService<TEntity, TInclude>
        where TEntity : EntityBase
        where TEntityResult : EntityResultBase
        where TInclude : struct, IConvertible
    {
        private static string GetIdsAttributeViaReflection()
        {
            var idProperty = typeof(TEntityResult).GetProperty("ids");
            var attribute = (JsonPropertyAttribute)idProperty
                .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                .First();
            return attribute.PropertyName;
        }

        static Lazy<string> _idsAttribute = new Lazy<string>(GetIdsAttributeViaReflection);

        private static string IdsAttribute
        {
            get
            {
                return _idsAttribute.Value;
            }
        }

        public CRUDService(IContext context, string className) : base(context, className) { }

        public IEnumerable<TEntity> Get(TInclude include, object filter = null, Dictionary<string, object> @params = null)
        {
            return Get(filter: filter, include: new List<TInclude>() { include }, @params: @params);
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(TInclude include, object filter = null, Dictionary<string, object> @params = null)
        {
            return await GetAsync(filter: filter, include: new List<TInclude>() { include }, @params: @params);
        }

        public IEnumerable<TEntity> GetById(IEnumerable<string> ids, IEnumerable<TInclude> include = null)
        {
            Check.IEnumerableNotNullOrEmpty(ids, "ids");

            var @params = new Dictionary<string, object>();
            @params.Add(IdsAttribute, ids);
            return Get(
                @params: @params,
                include: include
            );
        }

        public async Task<IReadOnlyList<TEntity>> GetByIdAsync(IEnumerable<string> ids, IEnumerable<TInclude> include = null)
        {
            Check.IEnumerableNotNullOrEmpty(ids, "ids");

            var @params = new Dictionary<string, object>();
            @params.Add(IdsAttribute, ids);
            return await GetAsync(
                @params: @params,
                include: include
            );
        }

        public TEntity GetById(string id, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(id, "id");

            return GetById(
                ids: new List<string>() { id },
                include: include
            ).FirstOrDefault();
        }

        public async Task<TEntity> GetByIdAsync(string id, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(id, "id");

            return (await GetByIdAsync(
                ids: new List<string>() { id },
                include: include
            )).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetById(IEnumerable<long> ids, IEnumerable<TInclude> include = null)
        {
            Check.IEnumerableNotNullOrEmpty(ids, "ids");

            return GetById(
                ids: ids.Select(x => x.ToString()),
                include: include
            );
        }

        public TEntity GetById(long id, IEnumerable<TInclude> include = null)
        {
            return GetById(
                ids: new List<long>() { id },
                include: include
            ).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetByProperty(string name, IEnumerable<object> values, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(name, "name");
            Check.IEnumerableNotNullOrEmpty(values, "values");

            var filter = new Dictionary<string, object>();
            filter.Add(name, values.Select(x => x.ToString()));
            return Get(
                filter: filter,
                include: include
            );
        }

        public async Task<IReadOnlyList<TEntity>> GetByPropertyAsync(string name, IEnumerable<object> values, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(name, "name");
            Check.IEnumerableNotNullOrEmpty(values, "values");

            var filter = new Dictionary<string, object>();
            filter.Add(name, values.Select(x => x.ToString()));
            return await GetAsync(
                filter: filter,
                include: include
            );
        }

        public TEntity GetByProperty(string name, object value, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(name, "name");
            Check.NotNull(value, "value");

            return GetByProperty(
                name: name,
                values: new List<string>() { value.ToString() },
                include: include
            ).FirstOrDefault();
        }

        public async Task<TEntity> GetByPropertyAsync(string name, object value, IEnumerable<TInclude> include = null)
        {
            Check.IsNotNullOrWhiteSpace(name, "name");
            Check.NotNull(value, "value");

            return (await GetByPropertyAsync(
                name: name,
                values: new List<string>() { value.ToString() },
                include: include
            )).FirstOrDefault();
        }

        public IEnumerable<string> Create(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities);

            return _context.SendRequest<TEntityResult>(entities, _className + ".create").ids;
        }

        public async Task<IReadOnlyList<string>> CreateAsync(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities);

            return (await _context.SendRequestAsync<TEntityResult>(entities, _className + ".create")).ids;
        }

        public string Create(TEntity entity)
        {
            Check.NotNull(entity, "entity");

            return Create(new List<TEntity>() { entity }).FirstOrDefault();
        }

        public async Task<string> CreateAsync(TEntity entity)
        {
            Check.NotNull(entity, "entity");

            return (await CreateAsync(new List<TEntity>() { entity })).FirstOrDefault();
        }

        public IEnumerable<string> Update(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            return _context.SendRequest<TEntityResult>(entities, _className + ".update").ids;
        }

        public async Task<IReadOnlyList<string>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            return (await _context.SendRequestAsync<TEntityResult>(entities, _className + ".update")).ids;
        }

        public string Update(TEntity entity)
        {
            Check.EntityHasId(entity);

            return Update(new List<TEntity>() { entity }).FirstOrDefault();
        }

        public async Task<string> UpdateAsync(TEntity entity)
        {
            Check.EntityHasId(entity);

            return (await UpdateAsync(new List<TEntity>() { entity })).FirstOrDefault();
        }

        public IEnumerable<string> CreateOrUpdate(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            var objectsToCreate = entities.Where(x => x.Id == null);
            var objectsToUpdate = entities.Where(x => x.Id != null);

            var result = new List<string>();

            if (objectsToCreate.Any())
                result.AddRange(Create(objectsToCreate));

            if (objectsToUpdate.Any())
                result.AddRange(Update(objectsToUpdate));

            return result;
        }

        public async Task<IEnumerable<string>> CreateOrUpdateAsync(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            var objectsToCreate = entities.Where(x => x.Id == null);
            var objectsToUpdate = entities.Where(x => x.Id != null);

            var result = new List<string>();

            if (objectsToCreate.Any())
                result.AddRange(await CreateAsync(objectsToCreate));

            if (objectsToUpdate.Any())
                result.AddRange(await UpdateAsync(objectsToUpdate));

            return result;
        }

        public string CreateOrUpdate(TEntity entity)
        {
            Check.NotNull(entity);

            if (entity.Id == null)
                return Create(new List<TEntity>() { entity }).FirstOrDefault();
            else
                return Update(new List<TEntity>() { entity }).FirstOrDefault();
        }

        public async Task<string> CreateOrUpdateAsync(TEntity entity)
        {
            Check.NotNull(entity);

            return (await CreateOrUpdateAsync(new[] { entity })).FirstOrDefault();
        }

        public IEnumerable<string> Delete(IEnumerable<string> ids)
        {
            Check.IEnumerableNotNullOrEmpty(ids, "ids");

            return _context.SendRequest<TEntityResult>(ids, _className + ".delete").ids;
        }

        public async Task<IReadOnlyList<string>> DeleteAsync(IEnumerable<string> ids)
        {
            Check.IEnumerableNotNullOrEmpty(ids, "ids");

            return (await _context.SendRequestAsync<TEntityResult>(ids, _className + ".delete")).ids;
        }

        public string Delete(string id)
        {
            Check.IsNotNullOrWhiteSpace(id, "id");

            return Delete(new List<string>() { id }).FirstOrDefault();
        }

        public async Task<string> DeleteAsync(string id)
        {
            Check.IsNotNullOrWhiteSpace(id, "id");

            return (await DeleteAsync(new List<string>() { id })).FirstOrDefault();
        }

        public IEnumerable<string> Delete(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            return Delete(entities.Select(x => x.Id));
        }

        public async Task<IReadOnlyList<string>> DeleteAsync(IEnumerable<TEntity> entities)
        {
            Check.IEnumerableNotNullOrEmpty(entities, "entities");

            return await DeleteAsync(entities.Select(x => x.Id));
        }

        public string Delete(TEntity entity)
        {
            Check.EntityHasId(entity);

            return Delete(entity.Id);
        }

        public async Task<string> DeleteAsync(TEntity entity)
        {
            Check.EntityHasId(entity);

            return await DeleteAsync(entity.Id);
        }
    }
}
