using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Actio.Common.MongoDB
{
    public class MongoDbInitializer : IDatabaseInitializer
    {
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _seeder;
        private readonly IOptions<MongoDbOptions> _options;
        private readonly bool _seed;
        private bool _initialized;

        public MongoDbInitializer(IMongoDatabase database, IDatabaseSeeder seeder, IOptions<MongoDbOptions> options)
        {
            _database = database;
            _seeder = seeder;
            _seed = options.Value.Seed;
        }

        public async Task InitializeAsync()
        {
            if (_initialized) return;
            RegisterConventions();
            _initialized = true;
            if (!_seed) return;
            await _seeder.SeedAsync();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoDbConvention(), x => true);
        }
    }
}