using MongoDB.Bson;

namespace DotNet_CRUD_with_MongoDb.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Vehicle { get; set; }
    }
}