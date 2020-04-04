using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actio.Common.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RawRabbit;
using RawRabbit.Instantiation;

namespace Actio.Common.MongoDB
{
    public static class Extensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbOptions>(configuration.GetSection("MongoDB"));
            services.AddSingleton<MongoClient>(C =>
            {
                var options = C.GetService<IOptions<MongoDbOptions>>();

                return new MongoClient(options.Value.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(C =>
            {
                var options = C.GetService<IOptions<MongoDbOptions>>();
                var client = C.GetService<MongoClient>();

                return client.GetDatabase(options.Value.Database);
            });
            services.AddScoped<IDatabaseInitializer, MongoDbInitializer>();
            services.AddScoped<IDatabaseSeeder, MongoDbSeeder>();
        }
    }
}