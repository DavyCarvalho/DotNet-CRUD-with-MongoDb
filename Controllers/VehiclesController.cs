using DotNet_CRUD_with_MongoDb.Database;
using DotNet_CRUD_with_MongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DotNet_CRUD_with_MongoDb.Controllers
{
    [ApiController]
    [Route("vehicle")]
    public class VehiclesController : ControllerBase
    {
        private readonly Context _context;

        public VehiclesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetVehicles()
        {
            return new JsonResult(_context.Vehicles);
        }

        [HttpPost]
        public IActionResult Post(Vehicle vehicle)
        {
            vehicle.VehicleId = _context.Vehicles.GetNextVehicleId();

            _context.Vehicles.InsertOne(vehicle);

            return Ok("Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(Vehicle vehicle)
        {
            var filter = Builders<Vehicle>.Filter.Eq("VehicleId", vehicle.VehicleId);
            var update = Builders<Vehicle>.Update.Set("Name", vehicle.Name);

            _context.Vehicles.UpdateOne(filter, update);

            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filter = Builders<Vehicle>.Filter.Eq("VehicleId", id);
            _context.Vehicles.DeleteOne(filter);

            return Ok("Deleted Successfully");
        }
    }
}
