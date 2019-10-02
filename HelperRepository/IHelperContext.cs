using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace HelperRepository
{
    public interface IHelperContext<TEntity> where TEntity : class
    {
        IMongoCollection<TEntity> Entities { get; }
    }
}
