using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelperRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FetchById(string id);

        Task<IEnumerable<TEntity>> FetchByQuery(JObject jObject);

        Task<TEntity> Save(TEntity entity);

        Task<bool> DeleteById(string id);

        Task<bool> DeleteByQuery(JObject jObject);
    }
}
