using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Api.Repositories
{
    internal class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activities");

        public async Task<Activity> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId)
        {
            return await Collection.AsQueryable().Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Activity activity)
        {
            await Collection.InsertOneAsync(activity);
        }
    }
}