using MongoDB.Bson;

namespace DotNet_CRUD_with_MongoDb.Models
{
    public class Vehicle
    {
        public ObjectId Id { get; set; }
        public int VehicleId { get; set; }
        public string Name { get; set; }
    }
}