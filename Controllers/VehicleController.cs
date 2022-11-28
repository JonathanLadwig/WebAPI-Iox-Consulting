using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
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

        public VehicleController(IMediator mediator)
        {
            _mediator= mediator;    
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        //Get List of Vehicles Based Off Any Attribute. Should also return any vehicles belonging to a user.
        [HttpGet("{filter}")]
        public async Task<IActionResult> GetVehicleList(string filter)
        {
            var query = new GetVehicleListQuery(filter);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        //Add New Vehicle
        [HttpPost]
        public async Task<IActionResult> AddVehicle(Commands.AddVehicleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Renew Vehicle License
        [HttpPut("{vehicleID}")]
        public async Task<IActionResult> RenewLicense(int vehicleID)
        {
            var command = new RenewLicenseCommand(vehicleID);
            var result = await Mediator.Send(command);
            //if (result == null)
            //{
            //    return BadRequest();  
            //}
            return Ok(result);
        }
    }
}
