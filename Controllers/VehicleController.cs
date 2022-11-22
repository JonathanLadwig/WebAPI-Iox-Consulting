using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Commands;
using WebAPI_Test.Model;
using WebAPI_Test.Queries;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IoxDbContext _context;
        public VehicleController(IoxDbContext context) => _context = context;

        //Get List of Vehicles Based Off Any Attribute. Should also return any vehicles belonging to a user.
        //TODO: Change from vehicleID
        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleList(int vehicleID)
        {
            var query = new GetVehicleListQuery(vehicleID);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //Add New Vehicle
        [HttpPost]
        public async Task<IActionResult> AddVehicle(Commands.AddVehicleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Renew Vehicle License
        [HttpPut("{vehicleId}")]
        public async Task<IActionResult> RenewLicense(int vehicleID, RenewLicenseCommand command)
        {
            if (vehicleID != command.VehicleID) 
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
