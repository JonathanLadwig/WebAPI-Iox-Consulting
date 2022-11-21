using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleList(int vehicleID)
        {
            var query = new GetVehicleListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(Commands.AddVehicleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
