using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SharpCompress.Archives;

namespace Actio.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<User> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> GetAsync(string email) =>
            await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user) => await Collection.InsertOneAsync(user);

        private IMongoCollection<User> Collection => _database.GetCollection<User>("Users");
    }
}
