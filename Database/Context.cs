using System.Linq;
using DotNet_CRUD_with_MongoDb.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DotNet_CRUD_with_MongoDb.Database
{
    public class Context

    {
        private readonly IConfiguration _configuration;
        private IMongoDatabase _database { get; set; }

        public IMongoCollection<User> Users { get; set; }
        public IMongoCollection<Vehicle> Vehicles { get; set; }

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _database = new MongoClient(_configuration.GetConnectionString("MongoDbConnection")).GetDatabase("SampleDatabase");

            Users = _database.GetCollection<User>("Users");
            Vehicles = _database.GetCollection<Vehicle>("Vehicles");
        }
    }
}