using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace HelperRepository
{
    public class HelperContext<TEntity> : IHelperContext<TEntity> where TEntity : class
    {
        private readonly IOptions<HelperConfiguration> _configuration;

        private readonly IMongoDatabase _mongoDatabase = null;

        private readonly string _entityName = string.Empty;
        public HelperContext(IOptions<HelperConfiguration> configuration)
        {
            _configuration = configuration;

            var client = new MongoClient(_configuration.Value.ConnectionString);
            if (client != null)
            {
                _mongoDatabase = client.GetDatabase(_configuration.Value.Database);
            }

            _entityName = typeof(TEntity).Name;

        }

        public IMongoCollection<TEntity> Entities => _mongoDatabase.GetCollection<TEntity>(_entityName);
    }
}
