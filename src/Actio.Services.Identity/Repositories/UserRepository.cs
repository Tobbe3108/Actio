using System;
using System.Threading.Tasks;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Actio.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<User> Collection => _database.GetCollection<User>("Users");

        public async Task<User> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetAsync(string email)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Email == email.ToLowerInvariant());
        }

        public async Task AddAsync(User user)
        {
            await Collection.InsertOneAsync(user);
        }
    }
}