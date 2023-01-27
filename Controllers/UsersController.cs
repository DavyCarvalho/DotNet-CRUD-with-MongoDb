using DotNet_CRUD_with_MongoDb.Database;
using DotNet_CRUD_with_MongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DotNet_CRUD_with_MongoDb.Controllers
{
    [ApiController]
    [Route("user")]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            return new JsonResult(_context.Users);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            user.UserId = _context.Users.GetNextUserId();

            _context.Users.InsertOne(user);

            return Ok("Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            var filter = Builders<User>.Filter.Eq("UserId", user.UserId);
            var update = Builders<User>.Update
                .Set("Vehicle", user.Vehicle)
                .Set("Name", user.Name);

            _context.Users.UpdateOne(filter, update);

            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filter = Builders<User>.Filter.Eq("UserId", id);
            _context.Users.DeleteOne(filter);

            return Ok("Deleted Successfully");
        }
    }
}
