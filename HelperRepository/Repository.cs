using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MongoDB.Driver;
using HelperModel;
using System.Linq.Expressions;
using MongoDB.Bson;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace HelperRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IHelperContext<TEntity> _helperContext = null;
        private readonly IHelperModelBase _helperModelBase = null;

        //public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Repository(IHelperContext<TEntity> helperContext, IHelperModelBase helperModelBase)
        {
            _helperContext = helperContext;
            _helperModelBase = helperModelBase;
        }


        public async Task<TEntity> FetchById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                //return await _helperContext.Entities
                //    .Find(entity => entity.GetType().GetProperty(nameof(_helperModelBase.Id)).GetValue(entity).ToString() == id)
                //    .FirstOrDefaultAsync();

                var collection = _helperContext.Entities;

                var propName = nameof(_helperModelBase.Id);
                var jsonPropName = GetJsonFields(typeof(TEntity), propName);
                var query = CreateQueryExpression(propName, id);

                return await collection
                    .Find(query)
                    .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public Task<IEnumerable<TEntity>> FetchByQuery(JObject jObject)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByQuery(JObject jObject)
        {
            throw new NotImplementedException();
        }


        #region Private Methods
        private static Expression<Func<TEntity, bool>> CreateQueryExpression(string propertyName, string filterValue)
        {
            var notificationType = typeof(TEntity);
            var entity = Expression.Parameter(notificationType, "entity");
            var body = Expression.Equal(
                Expression.Property(entity, propertyName),
                Expression.Constant(ObjectId.Parse(filterValue)));

            return Expression.Lambda<Func<TEntity, bool>>(body, entity);
        }

        private static string GetJsonFields(Type modelType, string propName)
        {
            return string.Join(",",
                modelType.GetProperties().Where(p => p.Name == propName )
                         .Select(p => p.GetCustomAttribute<JsonPropertyAttribute>())
                         .Select(jp => jp.PropertyName));
        }

        #endregion
    }
}
