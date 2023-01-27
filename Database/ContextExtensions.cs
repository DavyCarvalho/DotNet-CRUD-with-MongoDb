using System.Linq;
using DotNet_CRUD_with_MongoDb.Models;
using MongoDB.Driver;

namespace DotNet_CRUD_with_MongoDb.Database
{
    public static class ContextExtensions
    {
        public static int GetNextUserId(this IMongoCollection<User> users)

        {
            return users.AsQueryable().Count() + 1;
        }

        public static int GetNextVehicleId(this IMongoCollection<Vehicle> vehicles)
        {
            return vehicles.AsQueryable().Count() + 1;
        }
    }
}