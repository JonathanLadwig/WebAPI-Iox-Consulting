using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Model;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IoxDbContext _context;
        public VehicleController(IoxDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() {
            IList<Vehicle> vehicles = _context.Vehicles.ToList();
            return Ok(vehicles);
        }


    }
}
